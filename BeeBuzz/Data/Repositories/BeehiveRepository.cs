using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeBuzz.Data.Repositories
{
    public class BeehiveRepository : BeeBuzzGenericRepository<Beehive>, IBeehiveRepository
    {
        public BeehiveRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Beehive> GetBeehivesByOrganization(Guid organizationId)
        {
            // Beehives are linked to users; I have to filter by the owner's OrganizationId
            return _dbSet
                .Include(b => b.Owner)
                .Where(b => b.Owner.OrganizationId == organizationId)
                .ToList();
        }
    }
}
