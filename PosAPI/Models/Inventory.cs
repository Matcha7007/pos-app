using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PosAPI.Models
{
    public class Inventory : BaseEntity
    {
        public Inventory(string name, int stock, string unit, int unitPrice)
        {
            this.Name = name;
            this.Stock = stock;
            this.Unit = unit;
            this.UnitPrice = unitPrice;
        }
        [Required]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Required]
        public int Stock { get; set; }
        public string Unit { get; set; }
        public int UnitPrice { get; set; }
    }
}