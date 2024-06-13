using FluentValidation;
using PryanikiTask.Application.Dto.Orders;

namespace PryanikiTask.Application.Validations.FluentValidations.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(3).WithMessage("Описание заказа короткое !");
        }
    }
}
