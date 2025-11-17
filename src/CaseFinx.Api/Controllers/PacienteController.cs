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

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetById(string cpf)
        {
            var paciente = await _service.Buscar(cpf);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Paciente p)
        {
            p.Id = Guid.NewGuid();

            await _service.Adicionar(p);

            var retorno = new
            {
                p.Nome,
                p.CPF,
                p.DataNascimento,
                p.Contato
            };

            return CreatedAtAction(nameof(GetById), new { id = p.Id }, retorno);
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
