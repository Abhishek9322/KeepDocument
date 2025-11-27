namespace KeepDocument.Helpers.JWTHelper
{
    public class JWTOption
    {
        public string SecretKey { get; set; }   
        public string Issuer { get; set; }  
        public string Audience { get; set; }    
    }
}
