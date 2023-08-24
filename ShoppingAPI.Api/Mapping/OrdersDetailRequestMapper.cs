﻿using AutoMapper;
using ShoppingAPI.Entity.DTO.OrderDetail;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Mapping
{
    public class OrdersDetailRequestMapper:Profile
    {
        public OrdersDetailRequestMapper()
        {
            CreateMap<OrderDetail, OrderDetailDTORequest>()
              
                .ForMember(dest => dest.OrderID, opt =>
                {
                    opt.MapFrom(src => src.OrderID);
                })
                .ForMember(dest => dest.ProductID, opt =>
                {
                    opt.MapFrom(src => src.ProductID);
                })
                .ForMember(dest => dest.Quantity, opt =>
                {
                    opt.MapFrom(src => src.Quantity);
                })
                .ForMember(dest => dest.UnitPrice, opt =>
                {
                    opt.MapFrom(src => src.UnitPrice);
                }).ReverseMap();
        }
    }
}
