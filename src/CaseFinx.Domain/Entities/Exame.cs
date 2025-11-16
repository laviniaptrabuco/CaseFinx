namespace CaseFinx.Domain.Entities
{
    public class Exame
    {
        public string Codigo { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateTime Data { get; set; }
        public string Resultado { get; set; } = null!;
    }
}
