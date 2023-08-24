using AutoMapper;
using ShoppingAPI.Entity.DTO.Order;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class OrderRequestMapper:Profile
    {
        public OrderRequestMapper()
        {
            CreateMap<Order, OrderDTORequest>()
                .ForMember(dest => dest.GUID, opt =>
                {
                    opt.MapFrom(src => src.GUID);
                })
                .ForMember(dest => dest.UserID, opt =>
                {
                    opt.MapFrom(src => src.UserID);
                }).ReverseMap();
        }
    }
}
