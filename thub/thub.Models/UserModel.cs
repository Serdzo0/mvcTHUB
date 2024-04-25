using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace thub.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("First Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(24)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }


    }
}
