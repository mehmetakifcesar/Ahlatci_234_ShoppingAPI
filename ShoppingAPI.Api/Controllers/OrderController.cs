using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.Business.Abstract;
using ShoppingAPI.Entity.DTO.Category;
using ShoppingAPI.Entity.DTO.Order;
using ShoppingAPI.Entity.DTO.User;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using System.Net;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("ShoppingAPI/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
       private readonly IUserService _userService;
        public OrderController(IOrderService orderService, IMapper mapper, IUserService userService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet("/Orders")]
        [ProducesResponseType(typeof(Sonuc<List<OrderDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllAsync(q => q.IsActive == true && q.IsDeleted == false, "Order");

            if (orders != null)
            {
                List<OrderDTOResponse> orderDtoResponseList = new List<OrderDTOResponse>();

                foreach (var order in orders)
                {
                    orderDtoResponseList.Add(_mapper.Map<OrderDTOResponse>(order));

                }

                return Ok(Sonuc<List<OrderDTOResponse>>.SuccessWithData(orderDtoResponseList));
            }

            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Order/{orderGUID}")]
        [ProducesResponseType(typeof(Sonuc<List<OrderDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrder(Guid orderGUID)
        {
            var order = await _orderService.GetAsync(q => q.GUID == orderGUID, "Order");

            if (order != null)
            {
                return Ok(Sonuc<OrderDTOResponse>.SuccessWithData(_mapper.Map<OrderDTOResponse>(order)));
            }

            else
            {
                return NotFound(Sonuc<List<CategoryDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPost("/AddOrder")]
        [ProducesResponseType(typeof(Sonuc<OrderDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddOrder(OrderDTORequest orderDTORequest)
        {
            var user = await _orderService.GetAsync(q => q.GUID == orderDTORequest.GUID);

            orderDTORequest.UserID = user.UserID;

            Order order = _mapper.Map<Order>(orderDTORequest);

            order.UserID = user.UserID;

            await _orderService.AddAsync(order);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
        [HttpPost("/UpdateOrder")]
        [ProducesResponseType(typeof(Sonuc<OrderDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(OrderDTORequest orderDTORequest)
        {
            Order order = await _orderService.GetAsync(q => q.GUID == orderDTORequest.GUID);

            order = _mapper.Map<Order>(orderDTORequest);

            await _orderService.UpdateAsync(order);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
        
        [HttpPost("/RemoveOrder/{orderGUID}")]
        [ProducesResponseType(typeof(Sonuc<OrderDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveOrder(Guid orderGUID)
        {
            Order order = await _orderService.GetAsync(q => q.GUID == orderGUID);

            order.IsActive = false;
            order.IsDeleted = true;
            await _orderService.UpdateAsync(order);
            return Ok(Sonuc<bool>.SuccessWithData(true));
        }
    }
}
