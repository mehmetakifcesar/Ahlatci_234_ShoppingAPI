using ShoppingAPI.Entity.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.OrderDetail
{
    public class OrderDetailDTOBase:BaseDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public double? Quantity { get; set; }
        public double? Discount { get; set; }
    }
}
