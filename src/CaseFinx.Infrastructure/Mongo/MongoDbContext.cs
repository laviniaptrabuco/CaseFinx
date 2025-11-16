using CaseFinx.Domain.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace CaseFinx.Infrastructure.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            var connectionString = config["Mongo:ConnectionString"];
            var databaseName = config["Mongo:Database"];

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Paciente> Pacientes =>
            _database.GetCollection<Paciente>("pacientes");

        public IMongoCollection<HistoricoPaciente> Historicos =>
            _database.GetCollection<HistoricoPaciente>("historicos");
    }
}
