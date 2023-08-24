using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.OrderDetail
{
    public class OrderDetailDTOResponse: OrderDetailDTOBase
    {
        public Guid GUID { get; set; }
    }
}
