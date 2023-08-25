using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTest.Application.DTOs.Validations
{
    public class AddressDtoValidator : AbstractValidator<AddressDTO>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty()
                .NotNull()
                .WithMessage("Street needs to be informed!");
            RuleFor(x => x.StreetNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("StreetNumber needs to be informed!");
            RuleFor(x => x.City)
                .NotEmpty()
                .NotNull()
                .WithMessage("City needs to be informed!");
        }
    }
}
