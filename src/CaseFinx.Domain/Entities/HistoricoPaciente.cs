using System;
using System.Collections.Generic;
using System.Text;

namespace CaseFinx.Domain.Entities
{
    public class HistoricoPaciente
    {
        public Guid Id { get; set; }
        public string PacienteId { get; set; }
        public string Diagnosticos { get; set; }
        public string ExamesRealizados { get; set; }
        public string Prescricoes { get; set; }
        public DateTime DataRegistro { get; set; }

        public HistoricoPaciente(Guid id, string pacienteId, string diagnosticos, string examesRealizados, string prescricoes, DateTime dataRegistro)
        {
            Id = Guid.NewGuid();
            PacienteId = pacienteId;
            Diagnosticos = diagnosticos;
            ExamesRealizados = examesRealizados;
            Prescricoes = prescricoes;
            DataRegistro = dataRegistro;
        }
    }
}
