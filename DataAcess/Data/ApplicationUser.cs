using Microsoft.AspNetCore.Identity;

namespace DataAcess.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
