using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; } = default!;
        public ICollection<Beehive> Beehives { get; set; } = new List<Beehive>();
    }
}
