using KeepDocument.DTOs.AuthDTOs;

namespace KeepDocument.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto);
        Task<AuthResponseDto>LoginAsync(LoginRequestDto dto);
    }
}
