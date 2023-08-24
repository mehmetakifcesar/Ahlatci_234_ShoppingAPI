using FluentValidation;
using ShoppingAPI.Entity.DTO.OrderDetail;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class OrderDetailValidator:AbstractValidator<OrderDetailDTORequest>
    {
        public OrderDetailValidator() 
        { 
            RuleFor(q=>q.OrderID).NotEmpty().WithMessage("Sipariş ID Boş Olamaz");
            RuleFor(q=>q.ProductID).NotEmpty().WithMessage("Ürün ID Boş Olamaz");
            RuleFor(q=>q.Quantity).NotEmpty().WithMessage("Ürün Adedi Boş Olamaz");
            RuleFor(q=>q.UnitPrice).NotEmpty().WithMessage("Ürün Fiyatı Boş Olamaz");
           

        }
    }
}
