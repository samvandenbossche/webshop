using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Cart
    {
        public long ID { get; set; }

        public string CartId { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
