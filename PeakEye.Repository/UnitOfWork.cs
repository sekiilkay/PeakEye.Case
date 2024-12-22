using PeakEye.Repository.Context;

namespace PeakEye.Repository
{
    public class UnitOfWork(PeakEyeContext context) : IUnitOfWork
    {
        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
