using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeakEye.Repository.Users;
using PeakEye.Repository.Vulnerabilities;

namespace PeakEye.Repository.Context
{
    public class PeakEyeContext(DbContextOptions<PeakEyeContext> context) : IdentityDbContext<AppUser,AppRole, string>(context)
    {
        public DbSet<Vulnerability> Vulnerabilities { get; set; }
    }
}
