using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CaseFinx.Domain.Entities
{
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [JsonIgnore] 
        public Guid Id { get; set; } 
        public string Nome { get; set; } 
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Contato { get; set; }
    }
}
