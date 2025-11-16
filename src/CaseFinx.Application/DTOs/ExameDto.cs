namespace CaseFinx.Application.DTOs
{
    public class ExameDto
    {
        public string Codigo { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateTime Data { get; set; }
        public string Resultado { get; set; } = null!;
    }
}
