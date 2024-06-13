using FluentValidation;
using PryanikiTask.Application.Dto.Products;

namespace PryanikiTask.Application.Validations.FluentValidations.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Укажите номер продукта ! ");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Укажите название продукта !")
                .MinimumLength(3).WithMessage("Название продукта короткое !");
            RuleFor(x => x.Price)
              .NotEmpty().WithMessage("Укажите цену продукта !")
                .GreaterThan(0);
            RuleFor(x => x.OrderId)
           .NotEmpty().WithMessage("Укажите заказ !")
             .GreaterThan(0);
        }
    }
}
