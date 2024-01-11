using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Business.Models
{
    public class IbgeValidation : AbstractValidator<IBGE>
    {
        public IbgeValidation() {
            RuleFor(i => i.id)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(i => i.State)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(i => i.City)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
