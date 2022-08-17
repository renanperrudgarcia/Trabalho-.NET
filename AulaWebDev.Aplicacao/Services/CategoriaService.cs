using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Dominio.Validacoes;
using AutoMapper;

namespace AulaWebDev.Aplicacao.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoriaDto>> CriarAsync(CategoriaDto categoriaDto)
        {
            if (categoriaDto == null)
                return ResultService.Fail<CategoriaDto>("Objeto nao pode ser nullo");

            var result = await new CategoriaDtoValidator().ValidateAsync(categoriaDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoriaDto>("Um ou mais erros foram encontrados", result);

            var categoriaPersistido = await _categoriaRepository.CriarAsync(_mapper.Map<Categoria>(categoriaDto));
            var categoriaDtoPersistido = _mapper.Map<CategoriaDto>(categoriaPersistido);

            return ResultService.Ok(categoriaDtoPersistido);
        }

        public async Task<ResultService> DeletarAsync(Guid categoriaId)
        {
            if (categoriaId == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("Id do categoria deve ser informado");

            var categoria = await _categoriaRepository.ObterPorIdAsync(categoriaId);
            if (categoria == null)
                return ResultService.Fail("Categoria nao encontrado");

            if (await _categoriaRepository.DeletarAsync(categoria))
                return ResultService.Ok("Categoria removido com sucesso");

            return ResultService.Fail("Ocorreu um erro ao remover o Categoria");
        }

        public async Task<ResultService> AlterarAsync(CategoriaDto categoriaDto)
        {
            if (categoriaDto.Id == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("ID precisa ser informado");

            var result = await new CategoriaDtoValidator().ValidateAsync(categoriaDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoriaDto>("Um ou mais erros foram encontrados", result);

            var categoria = await _categoriaRepository.ObterPorIdAsync(categoriaDto.Id);
            if (categoria == null)
                return ResultService.Fail("Categoria nao encontrado");

            //Mapeando propriedades informadas para edição, na entidade ja existente no banco!
            var categoriaAtualizado = _mapper.Map(categoriaDto, categoria);

            if (await _categoriaRepository.EditarAsync(categoriaAtualizado))
                return ResultService.Ok("Categoria editado com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o Categoria");
        }

        public async Task<ResultService> ObterPorIdAsync(Guid categoriaId)
        {
            if (categoriaId == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("Id do Categoria deve ser informado");

            var categoria = await _categoriaRepository.ObterPorIdAsync(categoriaId);
            if (categoria == null)
                return ResultService.Fail<CategoriaDto>("Categoria nao encontrado");

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return ResultService.Ok(categoriaDto);
        }

        public async Task<ResultService<ICollection<CategoriaDto>>> ObterTodosAsync()
        {
            var categorias = await _categoriaRepository.ObterTodosAsync();
            var categoriasMapeados = _mapper.Map<ICollection<CategoriaDto>>(categorias);
            return ResultService.Ok(categoriasMapeados);
        }
    }
}
