using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosAPI.Models
{
    public class Supplier : BaseEntity
    {
        public Supplier(string name, string address, string phone)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public string Address { get; set; }
        [Column(Order = 3)]
        public string Phone { get; set; }
    }
}