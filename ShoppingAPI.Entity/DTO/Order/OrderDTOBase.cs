using ShoppingAPI.Entity.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Order
{
    public class OrderDTOBase:BaseDTO
    {
        public Guid GUID { get; set; }
    
        public int UserID { get; set; }
    }
}
