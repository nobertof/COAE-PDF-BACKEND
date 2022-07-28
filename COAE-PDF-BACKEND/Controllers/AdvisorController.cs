using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvisorController : ControllerBase
    {
        AdvisorService _advisorService;

        public AdvisorController(AdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        [HttpGet]
        public IActionResult PegarAdvisors()
        {
            return Ok(_advisorService.PegarAdvisors());
        }
        [HttpGet("{id}")]
        public IActionResult PegarAdvisorPeloId(int id)
        {
            ReadAdvisorDto readDto = _advisorService.PegarAdvisorPeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CriarAdvisor([FromBody] CreateAdvisorDto createDto)
        {
            ReadAdvisorDto readDto = _advisorService.CriarAdvisor(createDto);
            return CreatedAtAction(nameof(PegarAdvisorPeloId), new { Id = readDto.Id }, readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarAdvisor(int id, [FromBody] UpdateAdvisorDto updateDto)
        {
            Result resultado = _advisorService.AtualizarAdvisor(id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarAdvisor(int id)
        {
            Result resultado = _advisorService.DeletarAdvisor(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
