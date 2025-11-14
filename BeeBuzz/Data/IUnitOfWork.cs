using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBeehiveRepository Beehives { get; }
        IBeeBuzzGenericRepository<Organization> Organizations { get; }

        void Complete();
    }
}
