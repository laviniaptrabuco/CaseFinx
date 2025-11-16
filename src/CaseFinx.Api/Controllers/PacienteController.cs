using CaseFinx.Application.Services;
using CaseFinx.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace CaseFinx.Api.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.Listar());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var paciente = await _service.Buscar(id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Paciente p)
        {
            await _service.Adicionar(p);
            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Paciente p)
        {
            p.Id = id;
            await _service.Atualizar(p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Remover(id);
            return NoContent();
        }

    }
}
