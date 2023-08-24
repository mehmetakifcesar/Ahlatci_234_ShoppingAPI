using AutoMapper;
using ShoppingAPI.Entity.DTO.Cart;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class CartResponseMapper : Profile
    {
        public CartResponseMapper()
        {
            CreateMap<Cart, CartDTOResponse>()
                .ForMember(dest => dest.Quantity, opt =>
                {
                    opt.MapFrom(src => src.Quantity);
                }).ReverseMap()
                .ForMember(dest => dest.TotalPrice, opt =>
                {
                    opt.MapFrom(src => src.TotalPrice);
                }).ReverseMap()
                .ForMember(dest => dest.ProductGuid, opt =>
                {
                    opt.MapFrom(src => src.GUID);
                }).ReverseMap(); 
        }
    }
}
