using AutoMapper;
using ShoppingAPI.Entity.DTO.Cart;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class CartReguestMapper:Profile
    {
        public CartReguestMapper()
        {
            CreateMap<Cart, CartDTORequest>()
                .ForMember(dest => dest.Quantity, opt =>
                {
                    opt.MapFrom(src => src.Quantity);
                }).ReverseMap()
                .ForMember(dest => dest.TotalPrice, opt =>
                {
                    opt.MapFrom(src => src.TotalPrice);
                }).ReverseMap();


        }
    }
}
