using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ShoppingAPI.Entity.DTO.Cart;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.Mapping
{
    public class CartMap:BaseMap<Cart>
    {
        public override void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            
        }
    }
}
