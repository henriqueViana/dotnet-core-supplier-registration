using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SupplierProject.Domain.Models;

namespace SupplierProject.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(c => c.PublicPlace)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches("^[0-9]*$").WithMessage("O campo {PropertyName} só aceita valores numéricos");

            RuleFor(c => c.Zipcode)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches("^[0-9]*$").WithMessage("O campo {PropertyName} só aceita valores numéricos");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("O campo {propertyName} é obrigatório")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("O campo {propertyName} é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("O campo {propertyName} é obrigatório")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
