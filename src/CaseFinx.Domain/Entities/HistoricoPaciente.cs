using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CaseFinx.Domain.Entities
{
    public class HistoricoPaciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [JsonIgnore]
        public Guid Id { get; set; }
        public required string PacienteId { get; set; }
        public required string Diagnosticos { get; set; }
        public required string ExamesRealizados { get; set; }
        public required string Prescricoes { get; set; }
        public required DateTime DataRegistro { get; set; }
    }
}
