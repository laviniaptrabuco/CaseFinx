using CaseFinx.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CaseFinx.Api.Controllers
{
    [ApiController]
    [Route("api/exameExterno")]
    public class ExameExternoController : ControllerBase
    {
        private readonly IExameExternoService _service;

        public ExameExternoController(IExameExternoService service)
        {
            _service = service;
        }

        [HttpGet("{pacienteId}")]
        public async Task<IActionResult> ObterExamesExternos(string pacienteId)
        {
            var exames = await _service.ObterExamesExternosAsync(pacienteId);
            if (exames == null) return NotFound();

            return Ok(exames);
        }
    }
}
