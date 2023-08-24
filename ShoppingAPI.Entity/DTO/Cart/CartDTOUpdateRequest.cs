using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Cart
{
    public class CartDTOUpdateRequest
    {
        public Guid Guid { get; set; }
        public double? Quantity { get; set; }
        public double? TotalPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
