using KeepDocument.Models;
using Microsoft.EntityFrameworkCore;

namespace KeepDocument.Data.DBContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
            
        }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
