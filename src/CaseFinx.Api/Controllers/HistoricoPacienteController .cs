using CaseFinx.Application.Services;
using CaseFinx.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace CaseFinx.Api.Controllers
{
    [ApiController]
    [Route("api/historicos")]
    public class HistoricoPacienteController : ControllerBase
    {
        private readonly HistoricoPacienteService _service;

        public HistoricoPacienteController(HistoricoPacienteService service)
        {
            _service = service;
        }

        [HttpGet("paciente/{pacienteId}")]
        public async Task<IActionResult> GetByPaciente(string pacienteId) =>
            Ok(await _service.ListarPorPaciente(pacienteId));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistoricoPaciente h)
        {
            await _service.Adicionar(h);
            return CreatedAtAction(nameof(GetByPaciente), new { pacienteId = h.PacienteId }, h);
        }

    }
}
