using FluentValidation;
using ShoppingAPI.Entity.DTO.Order;

namespace ShoppingAPI.Api.Validation.FluentValidation
{
    public class OrderValidator:AbstractValidator<OrderDTORequest>
    {
        public OrderValidator()
        {
            RuleFor(q=>q.UserID).NotEmpty().WithMessage("Kullanıcı ID Boş Olamaz");
        }
    }
}
