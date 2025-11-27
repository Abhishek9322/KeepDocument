using KeepDocument.DTOs.AuthDTOs;
using KeepDocument.Helpers.JWTHelper;
using KeepDocument.Models;
using KeepDocument.Repositories.Interfaces;
using KeepDocument.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography;
using System.Text;

namespace KeepDocument.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly GenerateJWT _jwt;
        public AuthService(IUserRepository repo,GenerateJWT jwt)
        {
            _repo = repo;
            _jwt = jwt;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            var existingUser=await _repo.GetByEmailAsync(dto.Email);
            if (existingUser != null) throw new Exception("User already exists !");


            CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var user = new ApplicationUser
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _repo.AddUserAsync(user);

          //  var token=_jwt.GenerateToken(user);

            return new AuthResponseDto
            {
                FullName = user.FullName,
              
              //  Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
              
            };  

        }
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        { 
            var user=await _repo.GetByEmailAsync(dto.Email);
            if (user == null) throw new Exception("Invalid Email Or Password !");

            if(!VerifyPasswordHash(dto.Password,user.PasswordHash,user.PasswordSalt))
                throw new Exception("Invalid Email Or Password !");

            var token=_jwt.GenerateToken(user); 

            return new AuthResponseDto
            {
                FullName = user.FullName,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };  
            
        }




        private void CreatePasswordHash(string password,out byte[] hash,out byte[] salt)
        {
            using var hmac = new HMACSHA3_512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA3_512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hash);
        }


    }
}
