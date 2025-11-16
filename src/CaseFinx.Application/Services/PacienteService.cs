using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;

namespace CaseFinx.Application.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Paciente>> Listar() => _repository.GetAll();
        public Task<Paciente> Buscar(Guid id) => _repository.GetById(id);
        public Task Adicionar(Paciente p) => _repository.Create(p);
        public Task Atualizar(Paciente p) => _repository.Update(p);
        public Task Remover(Guid id) => _repository.Delete(id);
    }
}
