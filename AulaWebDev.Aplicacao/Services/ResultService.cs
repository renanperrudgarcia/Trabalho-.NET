using FluentValidation.Results;

namespace AulaWebDev.Aplicacao.Services
{
    public class ResultService
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public ICollection<ValidacaoErro> Erros { get; set; }

        public static ResultService RequestError(string mensagem, ValidationResult validationResult)
            => new ResultService
            {
                Sucesso = false,
                Mensagem = mensagem,
                Erros = validationResult.Errors.Select(x => new ValidacaoErro { Campo = x.PropertyName, Mensagem = x.ErrorMessage }).ToList()
            };

        public static ResultService<T> RequestError<T>(string mensagem, ValidationResult validationResult)
            =>  new ResultService<T>
                {
                    Sucesso = false,
                    Mensagem = mensagem,
                    Erros = validationResult.Errors.Select(x => new ValidacaoErro { Campo = x.PropertyName, Mensagem = x.ErrorMessage }).ToList()
                };

        public static ResultService Fail(string mensagem)
            => new ResultService
            {
                Sucesso = false,
                Mensagem = mensagem
            };

        public static ResultService<T> Fail<T>(string mensagem)
            => new ResultService<T>
            {
                Sucesso = false,
                Mensagem = mensagem
            };

        public static ResultService Ok(string mensagem)
            => new ResultService
            {
                Sucesso = true,
                Mensagem = mensagem
            };


        public static ResultService<T> Ok<T>(T data)
            => new ResultService<T>
            {
                Sucesso = true,
                Data = data
            };
    }

    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
