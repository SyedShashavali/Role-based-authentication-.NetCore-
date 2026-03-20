using Microsoft.AspNetCore.Identity;
namespace WebApp11.Models
{
    public class AppUser:IdentityUser
    {
        public   string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
