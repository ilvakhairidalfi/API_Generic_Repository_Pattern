using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Employee")]
        [JsonIgnore]
        public int Id { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        [JsonIgnore]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
        public Employee? Employee { get; set; }
    }
}
