﻿using FluentValidation;
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

            RuleFor(i => i.Codigo)
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(i => i.UF)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2).WithMessage("O campo {PropertyName} precisa ter 2 carcteres");

            RuleFor(i => i.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
