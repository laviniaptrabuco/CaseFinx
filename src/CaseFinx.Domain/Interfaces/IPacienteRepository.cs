

using CaseFinx.Domain.Entities;

namespace CaseFinx.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetById(int id);
        Task<List<Paciente>> GetAll();
        Task<Paciente> Create(Paciente paciente);
        Task<Paciente> Update(Paciente paciente);
        Task<Paciente> Delete(Guid id);
    }
}
