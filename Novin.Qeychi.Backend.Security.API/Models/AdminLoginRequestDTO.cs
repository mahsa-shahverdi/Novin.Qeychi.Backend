namespace Novin.Qeychi.Backend.Security.API.Models
{
    public class AdminLoginRequestDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
