using BeeBuzz.Data.Entities;
using System;
using System.Collections.Generic;

namespace BeeBuzz.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IBeeBuzzGenericRepository<ApplicationUser> Users { get; }
        IBeeBuzzGenericRepository<Organization> Organizations { get; }
        IBeeBuzzGenericRepository<Beehive> Beehives { get; }

        IEnumerable<ApplicationUser> GetUsersByOrganization(Guid orgId);
        IEnumerable<Beehive> GetBeehivesByOrganization(Guid orgId);

        void Complete();
    }
}
