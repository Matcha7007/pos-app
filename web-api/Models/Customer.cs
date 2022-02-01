using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}