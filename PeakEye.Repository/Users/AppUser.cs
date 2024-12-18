using Microsoft.AspNetCore.Identity;

namespace PeakEye.Repository.Users
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
