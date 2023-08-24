using ShoppingAPI.Entity.Base;
using ShoppingAPI.Entity.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.Poco
{
    public class Cart:AuditableEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }
       

        public double? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
