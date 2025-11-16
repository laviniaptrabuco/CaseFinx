

using CaseFinx.Domain.Entities;

namespace CaseFinx.Domain.Interfaces
{
    public interface IHistoricoPacienteRepository
    {
        Task<HistoricoPaciente> GetById(Guid id);
        Task<List<HistoricoPaciente>> GetByPaciente(string pacientId);
        Task Create(HistoricoPaciente historicoPaciente);
        Task Update(HistoricoPaciente historicoPaciente);
        Task Delete(Guid id);

    }
}
