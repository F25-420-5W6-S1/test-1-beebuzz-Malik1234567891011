using BeeBuzz.Data.Entities;
using System;
using System.Collections.Generic;

namespace BeeBuzz.Data.Interfaces
{
    public interface IBeehiveRepository : IBeeBuzzGenericRepository<Beehive>
    {
        /// <summary>
        /// Returns all beehives for a given organization.
        /// This uses the organization of the hive owner (user).
        /// </summary>
        IEnumerable<Beehive> GetBeehivesByOrganization(Guid organizationId);
    }
}
