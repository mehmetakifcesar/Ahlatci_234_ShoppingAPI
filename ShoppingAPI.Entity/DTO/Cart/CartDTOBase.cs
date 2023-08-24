using ShoppingAPI.Entity.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Cart
{
    public class CartDTOBase:BaseDTO
    {
        public double? Quantity { get; set; }
        public double? TotalPrice { get; set; }
    }
}
