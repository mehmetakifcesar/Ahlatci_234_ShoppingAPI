using ShoppingAPI.Entity.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Cart
{
    public class CartDTOResponse:CartDTOBase
    {
        
        public Guid ProductGuid { get; set; }
    }
}
