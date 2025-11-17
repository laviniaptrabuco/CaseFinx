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
            h.Id = Guid.NewGuid();

            await _service.Adicionar(h);

            var retorno = new
            {
                h.PacienteId,
                h.Diagnosticos,
                h.ExamesRealizados,
                h.Prescricoes,
                h.DataRegistro
            };

            return CreatedAtAction(nameof(GetByPaciente), new { pacienteId = h.PacienteId }, retorno);
        }
    }
}
