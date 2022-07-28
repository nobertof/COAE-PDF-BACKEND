using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvisorProjectController : ControllerBase
    {
        AdvisorProjectService _advisorProjectService;

        public AdvisorProjectController(AdvisorProjectService advisorProjectService)
        {
            _advisorProjectService = advisorProjectService;
        }

        [HttpGet]
        public IActionResult PegarAdvisorProjects()
        {
            return Ok(_advisorProjectService.PegarAdvisorProjects());
        }
        [HttpGet("{id}")]
        public IActionResult PegarAdvisorProjectPeloId(int id)
        {
            ReadAdvisorProjectDto readDto = _advisorProjectService.PegarAdvisorProjectPeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CriarAdvisorProject([FromBody] CreateAdvisorProjectDto createDto)
        {
            ReadAdvisorProjectDto readDto = _advisorProjectService.CriarAdvisorProject(createDto);
            return CreatedAtAction(nameof(PegarAdvisorProjectPeloId), new { Id = readDto.Id }, readDto);

        }
        [HttpPut("{id}")]
        public IActionResult AtualizarAdvisorProject(int id, [FromBody] UpdateAdvisorProjectDto updateDto)
        {
            Result resultado = _advisorProjectService.AtualizarAdvisorProject(id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarAdvisorProject(int id)
        {
            Result resultado = _advisorProjectService.DeletarAdvisorProject(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
