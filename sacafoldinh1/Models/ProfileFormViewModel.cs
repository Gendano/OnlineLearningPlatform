using System.ComponentModel.DataAnnotations;

namespace sacafoldinh1.Models
{
    public class ProfileFormViewModel
    {

        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]


        public string FirstName { get; set; }
        public string LastName { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }


        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
