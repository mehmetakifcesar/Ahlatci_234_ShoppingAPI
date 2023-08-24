using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Order
{
    public class OrderDTOResponse:OrderDTOBase
    {
        public Guid GUID { get; set; }
    }
}
