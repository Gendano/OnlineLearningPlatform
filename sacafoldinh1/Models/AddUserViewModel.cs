﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace sacafoldinh1.Models
{
    public class AddUserViewModel:IdentityUser
    {
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
        public string? UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public byte[] ProfilePicture { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }

}
