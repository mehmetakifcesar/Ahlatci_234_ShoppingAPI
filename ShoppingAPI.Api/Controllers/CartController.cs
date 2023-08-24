using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shopping.Business.Abstract;
using ShoppingAPI.Api.Validation.FluentValidation;
using ShoppingAPI.Entity.DTO.Cart;
using ShoppingAPI.Entity.Poco;
using ShoppingAPI.Entity.Result;
using ShoppingAPI.Helper.CustomException;
using System.Net;

namespace ShoppingWEBUI.WebUI.Areas.UserPanel.Controllers
{
    [ApiController]
    [Route("ShoppingAPI/[action]")]
    public class CartController : Controller
    {
        // Sepete ekleme işlemi


        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IMapper mapper)
        {

            _cartService = cartService;
            _mapper = mapper;
        }
        [HttpPost("/AddCart")]
        [ProducesResponseType(typeof(Sonuc<CartDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddToCart(CartDTORequest cartDTORequest)
        {
            CartValidator cartValidator = new CartValidator();
            if (cartValidator.Validate(cartDTORequest).IsValid)
            {
                Cart cart = _mapper.Map<Cart>(cartDTORequest);
                await _cartService.AddAsync(cart);
                CartDTOResponse cartDTOResponse = _mapper.Map<CartDTOResponse>(cart);
                return Ok(Sonuc<CartDTOResponse>.SuccessWithData(cartDTOResponse));
            }
            else
            {
                List<string> validationMessages = new();
                for (int i = 0; i < cartValidator.Validate(cartDTORequest).Errors.Count; i++)
                {
                    validationMessages.Add(cartValidator.Validate(cartDTORequest).Errors[i].ErrorMessage);
                }
                throw new FieldValidationException(validationMessages);
            }
        }
        [HttpGet("/Carts")]
        [ProducesResponseType(typeof(Sonuc<List<CartDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCarts()
        {
            var carts = await _cartService.GetAllAsync(q=>q.IsActive == null && q.IsDeleted == false);
            if(carts is not null)
            {
                List<CartDTOResponse> cartDTOResponses = _mapper.Map<List<CartDTOResponse>>(carts);
                return Ok(Sonuc<List<CartDTOResponse>>.SuccessWithData(cartDTOResponses));

            }
            else
            {
               return NotFound(Sonuc<List<CartDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpGet("/Cart/{guid}")]
        [ProducesResponseType(typeof(Sonuc<List<CartDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCartByGuid(Guid guid)
        {
            var carts = await _cartService.GetAllAsync( q=>q.GUID == guid);
            if (carts is not null)
            {
                List<CartDTOResponse> cartDTOResponses = _mapper.Map<List<CartDTOResponse>>(carts);
                return Ok(Sonuc<List<CartDTOResponse>>.SuccessWithData(cartDTOResponses));

            }
            else
            {
                return NotFound(Sonuc<List<CartDTOResponse>>.SuccessNoDataFound());
            }
        }
        [HttpPut("/UpdateCart")]
        [ProducesResponseType(typeof(Sonuc<CartDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCart(CartDTOUpdateRequest cartDTOUpdateRequest)
        {
            Cart cart = await _cartService.GetAsync(q => q.GUID == cartDTOUpdateRequest.Guid);

            cart.TotalPrice = cartDTOUpdateRequest.TotalPrice;
            cart.Quantity = cartDTOUpdateRequest.Quantity;
            cart.IsActive = cartDTOUpdateRequest.IsActive != null ? cartDTOUpdateRequest.IsActive :
                cart.IsActive;

            await _cartService.UpdateAsync(cart);

            return Ok();
                
        }
        [HttpDelete("/RemoveCart/{guid}")]
        [ProducesResponseType(typeof(Sonuc<CartDTOResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveCart(Guid guid)
        {
          Cart cart= await _cartService.GetAsync(q => q.GUID == guid);
            cart.IsActive = false;
            cart.IsDeleted = true;
            await _cartService.UpdateAsync(cart);

            return Ok(Sonuc<bool>.SuccessWithData(true));
        }

                
    }
}


