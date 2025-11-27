namespace KeepDocument.DTOs.AuthDTOs
{
    public class AuthResponseDto
    {
        public string FullName {  get; set; }
        public string Token { get; set; }   
        public DateTime ExpiresAt { get; set; } 
    }


}
