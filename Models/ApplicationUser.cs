using Microsoft.AspNetCore.Identity;
using Freelance.Models;

namespace Freelance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Allow 2 username changes for this account
        public int UsernameChangeLimit { get; set; } = 2;

        public byte[] ProfilePicture { get; set; }
    }
}
