using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Departement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        [ForeignKey("DivisionId")]
        [JsonIgnore]
        // Json ignore fungsinya agar di post departement tidak menampilkan atribut division lagi

        public Division? Divisions { get; set; }
        // Tanda tanya setelah Division artinya boleh null


        //public ICollection<Division> Divisions { get; set; }
        /*
            bentuk one to many
            artinya, division dimiliki banyak departement
        */
    }
}
