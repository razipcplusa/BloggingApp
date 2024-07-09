using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BloggingApp.Model
{
    public class User : IdentityUser
    {

        //[Key]
        //public int UserId { get; set; }
        //[Required]
        //public string UserName { get; set; }
        //[Required]
        //public string Password { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; }
    }
}
