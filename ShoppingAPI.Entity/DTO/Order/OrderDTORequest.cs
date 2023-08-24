using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Order
{
    public class OrderDTORequest:OrderDTOBase
    {
        public int UserID { get; set; }
    }
}
