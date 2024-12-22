namespace PeakEye.Repository
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
