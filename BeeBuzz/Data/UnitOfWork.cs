using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }
        public IBeehiveRepository Beehives { get; }
        public IBeeBuzzGenericRepository<Organization> Organizations { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Beehives = new BeehiveRepository(_context);
            Organizations = new BeeBuzzGenericRepository<Organization>(_context);
        }

        public void Complete() => _context.SaveChanges();
    }
}
