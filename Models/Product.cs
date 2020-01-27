using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtCompany.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public TShirtCompany.Models.Type Type { get; set; }
        public Size Size { get; set; }
    }
}
