using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace sacafoldinh1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

    

        public string ? ProfilePicturePath { get; set; }
    }
}