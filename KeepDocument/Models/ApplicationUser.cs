namespace KeepDocument.Models
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string FullName { get; set; } 

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
