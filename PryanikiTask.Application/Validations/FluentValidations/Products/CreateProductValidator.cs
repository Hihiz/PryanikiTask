using FluentValidation;
using PryanikiTask.Application.Dto.Products;

namespace PryanikiTask.Application.Validations.FluentValidations.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Укажите название продукта !")
                .MinimumLength(3).WithMessage("Название продукта короткое !");
            RuleFor(x => x.Price)
              .NotEmpty().WithMessage("Укажите цену продукта !")
                .GreaterThan(0);
        }
    }
}
