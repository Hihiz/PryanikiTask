using FluentValidation;
using PryanikiTask.Application.Dto.Orders;

namespace PryanikiTask.Application.Validations.FluentValidations.Orders
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Укажите номер заказа ! ");
            RuleFor(x => x.Description)
              .MinimumLength(3).WithMessage("Описание заказа короткое !");
        }
    }
}
