using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;

namespace CaseFinx.Application.Services
{

    public class HistoricoPacienteService
    {
        private readonly IHistoricoPacienteRepository _repository;

        public HistoricoPacienteService(IHistoricoPacienteRepository repo)
        {
            _repository = repo;
        }

        public Task<List<HistoricoPaciente>> ListarPorPaciente(string pacienteId) =>
            _repository.GetByPaciente(pacienteId);

        public Task<HistoricoPaciente> Buscar(Guid id) => _repository.GetById(id);

        public Task Adicionar(HistoricoPaciente h) => _repository.Create(h);
    }
}
