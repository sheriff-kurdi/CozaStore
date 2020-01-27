using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtCompany.Models
{
    public class OrderRequestVM
    {

        public int id { get; set; }
        [Required]
        public int ItemNumbers { get; set; }
        [Required]
        public Product product { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string CustomerName { get; set; }

    }
}
