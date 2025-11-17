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
        public required string Nome { get; set; } 
        public required string CPF { get; set; }
        public required DateTime DataNascimento { get; set; }
        public string? Contato { get; set; }
    }
}
