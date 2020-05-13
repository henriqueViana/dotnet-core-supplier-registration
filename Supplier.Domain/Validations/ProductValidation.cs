using FluentValidation;
using SupplierProject.Domain.Models;

namespace SupplierProject.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} catacteres");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(3, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} catacteres");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
