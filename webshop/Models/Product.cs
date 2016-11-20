using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webshop.Models
{
    public class Product
    {
        public long ID { get; set; }
        
        public string Description { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Has to be decimal with two decimal points")]
        [Range(0, 5, ErrorMessage = "The maximum possible value should be upto 5 digits")]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public long CategoryId { get; set; }
        
        /*virtual is used to enable lazy loading 
        
         Lazy loading is the process whereby an entity or collection of 
         entities is automatically loaded from the database 
         the first time that a property referring to the entity/entities is accessed
         */
        
        public virtual Category Category { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}