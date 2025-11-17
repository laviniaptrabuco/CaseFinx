using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;
using CaseFinx.Infrastructure.Mongo;

using MongoDB.Driver;

namespace CaseFinx.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IMongoCollection<Paciente> _collection;

        public PacienteRepository(MongoDbContext context)
        {
            _collection = context.Pacientes;
        }

        public Task<Paciente> GetById(string cpf) =>
            _collection.Find(p => p.CPF == cpf).FirstOrDefaultAsync();

        public Task<List<Paciente>> GetAll() =>
            _collection.Find(_ => true).ToListAsync();

        public Task Create(Paciente paciente) =>
            _collection.InsertOneAsync(paciente);

        public Task Update(Paciente paciente) =>
            _collection.ReplaceOneAsync(p => p.Id == paciente.Id, paciente);

        public Task Delete(Guid id) =>
            _collection.DeleteOneAsync(p => p.Id == id);

    }
}
