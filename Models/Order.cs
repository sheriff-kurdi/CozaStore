using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtCompany.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }

        [Required]
        public int ItemNumbers { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public int TotallCost { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Image { get; set; }


    }
}
