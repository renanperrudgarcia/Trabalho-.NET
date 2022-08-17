namespace AulaWebDev.Dominio.DTOs
{
    public class PedidoResponseDto
    {
        public Guid Id { get; set; }
        public ProdutoResponseDto Produto { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
