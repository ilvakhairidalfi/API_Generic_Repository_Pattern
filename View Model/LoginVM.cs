using System.ComponentModel.DataAnnotations;

namespace API.View_Model
{
    public class LoginVM
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
