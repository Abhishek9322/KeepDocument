using KeepDocument.Data.DBContext;
using KeepDocument.Models;
using KeepDocument.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeepDocument.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;   
        }
        public async Task<ApplicationUser> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        
      
        public async Task AddUserAsync(ApplicationUser user)
        {
             await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        
    }
}
