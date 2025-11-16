

using CaseFinx.Domain.Entities;

namespace CaseFinx.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetById(Guid id);
        Task<List<Paciente>> GetAll();
        Task Create(Paciente paciente);
        Task Update(Paciente paciente);
        Task Delete(Guid id);
    }
}
