using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpTest.Application.DTOs.Validations
{
    public class ClientDtoValidator : AbstractValidator<ClientDTO>
    {
        public ClientDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name needs to be informed!");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone needs to be informed!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email needs to be informed!");
        }
    }
}
