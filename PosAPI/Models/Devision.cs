using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosAPI.Models
{
    public class Devision : BaseEntity
    {
        public Devision(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}