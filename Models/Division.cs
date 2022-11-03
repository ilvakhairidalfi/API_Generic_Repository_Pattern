using System.ComponentModel.DataAnnotations;
using Castle.Components.DictionaryAdapter;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace API.Models
{
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
