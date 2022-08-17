using AulaWebDev.Dominio.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Validacoes
{
    public class ProdutoDtoValidator : AbstractValidator<ProdutoDto>
    {
        public ProdutoDtoValidator()
        {
            ValidarCodigo();
            ValidarDescricao();
            ValidarQuantidadeEstoque();
            ValidarValor();
            ValidarCodigoCategoria();
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

        private void ValidarQuantidadeEstoque()
        {
            RuleFor(x => x.QuantidadeEstoque)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantidade em estoque deve ser informado");

            RuleFor(x => x.QuantidadeEstoque)
                .GreaterThan(0)
                .WithMessage("Quantidade em estoque deve ser maior que 0");
        }

        private void ValidarValor()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Valor deve ser informado");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("Valor deve ser maior que 0");
        }

        private void ValidarCodigoCategoria()
        {
            RuleFor(x => x.CodigoCategoria)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado");

            RuleFor(x => x.CodigoCategoria)
                .GreaterThan(0)
                .WithMessage("Codigo deve ser maior que 0");
        }
    }
}
