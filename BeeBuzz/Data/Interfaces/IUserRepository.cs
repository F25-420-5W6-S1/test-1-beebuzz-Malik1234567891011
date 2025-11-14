using BeeBuzz.Data.Entities;
using System;
using System.Collections.Generic;

namespace BeeBuzz.Data.Interfaces
{
    public interface IUserRepository : IBeeBuzzGenericRepository<ApplicationUser>
    {
        /// <summary>
        /// Returns all users that belong to a given organization.
        /// </summary>
        IEnumerable<ApplicationUser> GetUsersByOrganization(Guid organizationId);
    }
}
