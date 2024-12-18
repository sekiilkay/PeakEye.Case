namespace PeakEye.Service.Users.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationCode { get; set; }
    }
}
