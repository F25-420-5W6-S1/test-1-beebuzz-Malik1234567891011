using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeeBuzz.Data.Repositories
{
    public class UserRepository : BeeBuzzGenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<ApplicationUser> GetUsersByOrganization(Guid organizationId)
        {
            
            return _context.Users
                .Include(u => u.Organization)
                .Where(u => u.OrganizationId == organizationId)
                .ToList();
        }
    }
}
