using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;
using CaseFinx.Infrastructure.Mongo;

using MongoDB.Driver;

namespace CaseFinx.Infrastructure.Repositories
{
    public class HistoricoPacienteRepository : IHistoricoPacienteRepository
    {
        private readonly IMongoCollection<HistoricoPaciente> _collection;

        public HistoricoPacienteRepository(MongoDbContext context)
        {
            _collection = context.Historicos;
        }

        public Task<HistoricoPaciente> GetById(Guid id) =>
            _collection.Find(h => h.Id == id).FirstOrDefaultAsync();

        public Task<List<HistoricoPaciente>> GetByPaciente(string pacienteId) =>
            _collection.Find(h => h.PacienteId == pacienteId).ToListAsync();

        public Task Create(HistoricoPaciente historico) =>
            _collection.InsertOneAsync(historico);

        public Task Update(HistoricoPaciente historico) =>
           _collection.ReplaceOneAsync(p => p.Id == historico.Id, historico);

        public Task Delete(Guid id) =>
            _collection.DeleteOneAsync(p => p.Id == id);

    }
}
