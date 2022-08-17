namespace AulaWebDev.Dominio.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public string? Email { get; set; }
    }
}
