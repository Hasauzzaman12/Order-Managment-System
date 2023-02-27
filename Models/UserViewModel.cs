using Microsoft.AspNetCore.Identity;

namespace OMS.Models
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser>? Users { get; set; }
        public IEnumerable<IdentityRole>? Roles { get; set; }
    }
}
