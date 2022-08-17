using AulaWebDev.Dominio.DTOs;
using FluentValidation;

namespace AulaWebDev.Dominio.Validacoes
{
    public class PedidoDtoValidator : AbstractValidator<PedidoDto>
    {
        public PedidoDtoValidator()
        {
            ValidarDocumento();
            ValidarCodigo();
        }

        private void ValidarDocumento()
        {
            RuleFor(x => x.DocumentoCliente)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado");

            RuleFor(x => x.DocumentoCliente)
                .IsValidCPF()
                .WithMessage("CPF deve se valido");
        }

        private void ValidarCodigo()
        {
            RuleFor(x => x.CodigoProduto)
                .NotEmpty()
                .NotNull()
                .WithMessage("Codigo deve ser informado");

            RuleFor(x => x.CodigoProduto)
                .GreaterThan(0)
                .WithMessage("Codigo deve ser maior que 0");
        }
    }
}
