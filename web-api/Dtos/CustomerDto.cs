using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_api.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name is mandatory field.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}