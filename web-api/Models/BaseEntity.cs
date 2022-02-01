using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public DateTime LastUpdateOn { get; set; } = DateTime.Now;
        public int LastUpdateBy { get; set; }
    }
}