using System;
using System.Collections.Generic;

namespace webshop.Models
{
    public class Product
    {
        public long ID { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        /*virtual is used to enable lazy loading 
        
         Lazy loading is the process whereby an entity or collection of 
         entities is automatically loaded from the database 
         the first time that a property referring to the entity/entities is accessed
         */
        public virtual Category Category { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}