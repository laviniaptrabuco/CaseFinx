using CaseFinx.Api.Controllers;
using CaseFinx.Application.Services;
using CaseFinx.Domain.Entities;
using CaseFinx.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CaseFinx.Tests
{
    public class PacienteControllerTests
    {
        private readonly Mock<IPacienteRepository> _repoMock;
        private readonly PacienteService _service;
        private readonly PacienteController _controller;

        public PacienteControllerTests()
        {
            _repoMock = new Mock<IPacienteRepository>();
            _service = new PacienteService(_repoMock.Object);
            _controller = new PacienteController(_service);
        }

        [Fact]
        public async Task GetDeveRetornarOkComLista()
        {
            _repoMock.Setup(r => r.GetAll())
                .ReturnsAsync(
                [
                    new() { Id = Guid.NewGuid(), Nome = "Teste", CPF = "123", DataNascimento = DateTime.UtcNow }
                ]);

            var result = await _controller.Get();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var lista = Assert.IsType<List<Paciente>>(okResult.Value);
            Assert.Single(lista);
        }

        [Fact]
        public async Task GetByCPFDeveRetornarPaciente()
        {
            var paciente = new Paciente { Id = Guid.NewGuid(), Nome = "Teste", CPF = "123", DataNascimento = DateTime.UtcNow };
            _repoMock.Setup(r => r.GetByCPF("123")).ReturnsAsync(paciente);

            var result = await _controller.GetByCPF("123");
            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<Paciente>(okResult.Value);
            Assert.Equal("123", retorno.CPF);
        }

        [Fact]
        public async Task PostDeveRetornarCreatedSemIdExposto()
        {
            var paciente = new Paciente { Nome = "Teste", CPF = "12345678900", DataNascimento = DateTime.UtcNow };

            var result = await _controller.Post(paciente);
            var created = Assert.IsType<CreatedAtActionResult>(result);

            dynamic retorno = created.Value
                .GetType()
                .GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(created.Value));


            Assert.False(retorno.ContainsKey("Id"));  // garante que Id não está exposto
            Assert.Equal("Teste", retorno["Nome"]);
            Assert.Equal("12345678900", retorno["CPF"]);
        }
    }
}