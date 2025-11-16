using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseFinx.Domain.Entities
{
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Contato { get; set; }

        public Paciente(string nome, string cpf, DateTime dataNascimento, string? contato)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Contato = contato;
        }
    }
}
