using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webshop.Models
{
    public class Order
    {
        public long ID { get; set; }

        public long UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal Total { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
