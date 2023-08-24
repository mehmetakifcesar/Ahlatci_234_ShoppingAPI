using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.Business.Abstract;
using ShoppingAPI.Entity.DTO.OrderDetail;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("ShoppingAPI/[action]")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
            _orderService = orderService;
        }
        [HttpGet("/OrderDetails")]
        [ProducesResponseType(typeof(Sonuc<List<OrderDetailDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderDetails(Guid Guid)
        {
            var orderDetails = await _orderDetailService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false, "OrderDetail");

            if (orderDetails != null)
            {
                List<OrderDetailDTOResponse> orderDetailDtoResponseList = new List<OrderDetailDTOResponse>();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetailDtoResponseList.Add(_mapper.Map<OrderDetailDTOResponse>(orderDetail));

                }

                return Ok(Sonuc<List<OrderDetailDTOResponse>>.SuccessWithData(orderDetailDtoResponseList));
            }

            else
            {
                return NotFound(Sonuc<List<OrderDetailDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/OrderDetail/{orderDetailGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<OrderDetailDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderDetail(Guid orderDetailGUID)
        {
            var orderDetail = await _orderDetailService.GetAsync(q => q.GUID == orderDetailGUID, "OrderDetail");

            if (orderDetail != null)
            {
                return Ok(Sonuc<OrderDetailDTOResponse>.SuccessWithData(_mapper.Map<OrderDetailDTOResponse>(orderDetail)));
            }

            else
            {
                return NotFound(Sonuc<OrderDetailDTOResponse>.SuccessNoDataFound());
            }
        }
        [HttpPost("/AddOrderDetail")]
        [ProducesResponseType(typeof(Sonuc<OrderDetailDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddOrderDetail(OrderDetailDTORequest orderDetailDTORequest)
        {
            var order = await _orderService.GetAsync(q => q.GUID == orderDetailDTORequest.OrderGUID, "Order");

            if (order != null)
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTORequest);

                orderDetail.OrderID = order.ID;

                var addedOrderDetail = await _orderDetailService.AddAsync(orderDetail);

                if (addedOrderDetail != null)
                {
                    return Ok(Sonuc<OrderDetailDTOResponse>.SuccessWithData(_mapper.Map<OrderDetailDTOResponse>(addedOrderDetail)));
                }

                else
                {
                    return BadRequest(Sonuc<OrderDetailDTOResponse>.SuccessWithoutData());
                }
            }

            else
            {
                return NotFound(Sonuc<OrderDetailDTOResponse>.SuccessNoDataFound());
            }
        }
        [HttpPost("/UpdateOrderDetail")]
        [ProducesResponseType(typeof(Sonuc<OrderDetailDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailDTORequest orderDetailDTORequest)
        {
            var order = await _orderService.GetAsync(q => q.GUID == orderDetailDTORequest.OrderGUID, "Order");

            if (order != null)
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTORequest);

                orderDetail.OrderID = order.ID;

                var updatedOrderDetail =  _orderDetailService.UpdateAsync(orderDetail);

                if (updatedOrderDetail != null)
                {
                    return Ok(Sonuc<OrderDetailDTOResponse>.SuccessWithData(_mapper.Map<OrderDetailDTOResponse>(updatedOrderDetail)));
                }

                else
                {
                    return BadRequest(Sonuc<OrderDetailDTOResponse>.SuccessWithoutData());
                }
            }

            else
            {
                return NotFound(Sonuc<OrderDetailDTOResponse>.SuccessNoDataFound());
            }
        }
        [HttpPost("/DeleteOrderDetail")]
        [ProducesResponseType(typeof(Sonuc<OrderDetailDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrderDetail(OrderDetailDTORequest orderDetailDTORequest)
        {
            var order = await _orderService.GetAsync(q => q.GUID == orderDetailDTORequest.OrderGUID, "Order");

            if (order != null)
            {
                var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTORequest);

                orderDetail.OrderID = order.ID;

                var deletedOrderDetail =  _orderDetailService.RemoveAsync(orderDetail);

                if (deletedOrderDetail != null)
                {
                    return Ok(Sonuc<OrderDetailDTOResponse>.SuccessWithData(_mapper.Map<OrderDetailDTOResponse>(deletedOrderDetail)));
                }

                else
                {
                    return BadRequest(Sonuc<OrderDetailDTOResponse>.SuccessWithoutData());
                }
            }

            else
            {
                return NotFound(Sonuc<OrderDetailDTOResponse>.SuccessNoDataFound());
            }
        }
        
       
      
    }
}
