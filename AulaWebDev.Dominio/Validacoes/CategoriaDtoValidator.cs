using AulaWebDev.Dominio.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Validacoes
{
    public class CategoriaDtoValidator : AbstractValidator<CategoriaDto>
    {
        public CategoriaDtoValidator()
        {
            ValidarCodigo();
            ValidarDescricao();
        }

        private void ValidarCodigo()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado");
        }

        private void ValidarDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descricao deve ser informado");
        }

    }
}
