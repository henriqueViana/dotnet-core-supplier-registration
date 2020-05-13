using FluentValidation;
using SupplierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        private int cpfLength = 11;
        private int cnpjLength = 14;

        public SupplierValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(3, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Document)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Must(c => c.Length == cpfLength || c.Length == cnpjLength);
        }
    }
}
