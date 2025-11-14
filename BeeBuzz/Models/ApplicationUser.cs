using Microsoft.AspNetCore.Identity;

namespace ReseRaunt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
