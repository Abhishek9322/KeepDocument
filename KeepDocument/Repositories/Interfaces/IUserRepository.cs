using KeepDocument.Models;

namespace KeepDocument.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByEmailAsync(string email);    
        Task AddUserAsync(ApplicationUser user);    
    }
}
