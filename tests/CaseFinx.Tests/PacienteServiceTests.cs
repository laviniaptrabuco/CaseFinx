using CaseFinx.Application.Services;
using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;
using Moq;

namespace CaseFinx.Tests
{
    public class PacienteServiceTests
    {
        [Fact]
        public async Task AdicionarDeveChamarRepositorio()
        {
            var mockRepo = new Mock<IPacienteRepository>();
            var service = new PacienteService(mockRepo.Object);

            var paciente = new Paciente
            {
                Id = Guid.NewGuid(),
                Nome = "Teste",
                CPF = "12345678900",
                DataNascimento = DateTime.UtcNow
            };

            await service.Adicionar(paciente);

            // Assert
            mockRepo.Verify(r => r.Create(paciente), Times.Once);
        }
    }
}
