using System.ComponentModel.DataAnnotations;

namespace DDDSample1.Domain.Users
{
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        
        public string Role { get; set; }
       
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}