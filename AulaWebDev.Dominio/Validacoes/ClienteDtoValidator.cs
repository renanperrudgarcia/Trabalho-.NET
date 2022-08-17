using AulaWebDev.Dominio.DTOs;
using FluentValidation;

namespace AulaWebDev.Dominio.Validacoes
{
    public class ClienteDtoValidator : AbstractValidator<ClienteDto>
    {
        public ClienteDtoValidator()
        {
            ValidarNome();
            ValidarDocumento();
            ValidarEmail();
        }

        private void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome precisa ser informado!");
        }

        private void ValidarDocumento()
        {
            RuleFor(x => x.Documento)
                .NotNull()
                .NotEmpty()
                .WithMessage("Documento precisa ser informado!");

            RuleFor(x => x.Documento)
                .IsValidCPF()
                .WithMessage("O CPF Deve ser valido!");
        }

        private void ValidarEmail()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email precisa ser informado!");

            RuleFor(x => x.Email)
               .EmailAddress()
               .WithMessage("Informe um email valido!");
        }
    }
}
