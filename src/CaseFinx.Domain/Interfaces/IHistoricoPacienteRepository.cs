

using CaseFinx.Domain.Entities;

namespace CaseFinx.Domain.Interfaces
{
    public interface IHistoricoPacienteRepository
    {
        Task<HistoricoPaciente> GetById(int id);
        Task<List<HistoricoPaciente>> GetByPaciente(string pacientId);
        Task<HistoricoPaciente> Create(HistoricoPaciente historicoPaciente);
        Task<HistoricoPaciente> Update(HistoricoPaciente historicoPaciente);
        Task<HistoricoPaciente> Delete(Guid id);

    }
}
