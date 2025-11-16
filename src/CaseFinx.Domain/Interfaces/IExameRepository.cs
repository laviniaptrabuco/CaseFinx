using CaseFinx.Domain.Entities;

namespace CaseFinx.Domain.Interfaces
{
    public interface IExameRepository
    {
        Task<IEnumerable<Exame>> ObterExamesExternosAsync(string pacienteId);
    }
}
