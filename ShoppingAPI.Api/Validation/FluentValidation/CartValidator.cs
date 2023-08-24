using FluentValidation;
using ShoppingAPI.Entity.DTO.Cart;
using ShoppingAPI.Entity.Poco;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class CartValidator : AbstractValidator<CartDTORequest>
    {
        public CartValidator()
        {
            
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Fiyat 0 Olamaz");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Toplam Fiyat 0 Olamaz");
        }
    }
   

}
