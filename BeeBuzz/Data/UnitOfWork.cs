using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeBuzz.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBeeBuzzGenericRepository<ApplicationUser> Users { get; }
        public IBeeBuzzGenericRepository<Organization> Organizations { get; }
        public IBeeBuzzGenericRepository<Beehive> Beehives { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new BeeBuzzGenericRepository<ApplicationUser>(_context);
            Organizations = new BeeBuzzGenericRepository<Organization>(_context);
            Beehives = new BeeBuzzGenericRepository<Beehive>(_context);
        }

        public IEnumerable<ApplicationUser> GetUsersByOrganization(Guid orgId) =>
            Users.GetAll().Where(u => u.OrganizationId == orgId);

        public IEnumerable<Beehive> GetBeehivesByOrganization(Guid orgId) =>
            Beehives.GetAll().Where(b => b.Owner.OrganizationId == orgId);

        public void Complete() => _context.SaveChanges();
    }
}
