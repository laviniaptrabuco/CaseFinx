using CaseFinx.Api.Controllers;
using CaseFinx.Application.Services;
using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CaseFinx.Tests
{
    public class HistoricoPacienteControllerTests
    {
        private readonly Mock<IHistoricoPacienteRepository> _repoMock;
        private readonly HistoricoPacienteService _service;
        private readonly HistoricoPacienteController _controller;

        public HistoricoPacienteControllerTests()
        {
            _repoMock = new Mock<IHistoricoPacienteRepository>();
            _service = new HistoricoPacienteService(_repoMock.Object);
            _controller = new HistoricoPacienteController(_service);
        }

        [Fact]
        public async Task GetByPacienteDeveRetornarLista()
        {
            _repoMock.Setup(r => r.GetByPaciente("123"))
                .ReturnsAsync(
                [
                    new HistoricoPaciente
                    {
                        Id = Guid.NewGuid(),
                        PacienteId = "123",
                        Diagnosticos = "Teste",
                        ExamesRealizados = "Exame",
                        Prescricoes = "Prescricao",
                        DataRegistro = DateTime.UtcNow
                    }
                ]);

            var result = await _controller.GetByPaciente("123");
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lista = Assert.IsType<List<HistoricoPaciente>>(okResult.Value);
            Assert.Single(lista);
        }

        [Fact]
        public async Task PostDeveRetornarCreatedSemIdExposto()
        {
            var historico = new HistoricoPaciente
            {
                PacienteId = "123",
                Diagnosticos = "Dor lombar",
                ExamesRealizados = "Raio X",
                Prescricoes = "Fisioterapia",
                DataRegistro = DateTime.UtcNow
            };

            var result = await _controller.Post(historico);
            var created = Assert.IsType<CreatedAtActionResult>(result);

            dynamic retorno = created.Value
              .GetType()
              .GetProperties()
              .ToDictionary(h => h.Name, h => h.GetValue(created.Value));

            Assert.Equal("123", retorno["PacienteId"]);
            Assert.Equal("Dor lombar", retorno["Diagnosticos"]);
            Assert.Equal("Raio X", retorno["ExamesRealizados"]);
            Assert.Equal("Fisioterapia", retorno["Prescricoes"]);
        }
    }
}
