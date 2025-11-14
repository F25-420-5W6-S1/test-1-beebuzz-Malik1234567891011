using System;

namespace BeeBuzz.Data.Entities
{
    public class Beehive
    {
        public Guid Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = "Active"; // Active/Inactive
        public string? DeactivationReason { get; set; } // Dead/Sold
        public string Name { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser Owner { get; set; } = default!;
    }
}
