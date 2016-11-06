using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webshop.Models;

namespace webshop.Models
{
    public class Category
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Product { get; set; }
    }
}
