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
        public string PacienteId { get; set; }
        public string Diagnosticos { get; set; }
        public string ExamesRealizados { get; set; }
        public string Prescricoes { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
