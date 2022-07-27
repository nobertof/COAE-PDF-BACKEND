using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController:ControllerBase
    {
        private ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult PegarProjetos()
        {

            return Ok(_projectService.PegarProjetos());
        }
        [HttpGet("{id}")]
        public IActionResult PegarProjetoPorId(int Id)
        {
            ReadProjectDto readDto = _projectService.PegarProjetosPorId(Id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CadastrarProjeto([FromBody] CreateProjectDto createDto)
        {
            ReadProjectDto readDto = _projectService.CadastrarProjeto(createDto);
            return CreatedAtAction(nameof(PegarProjetoPorId), new {Id=readDto.Id}, readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarProjeto(int Id, [FromBody] UpdateProjectDto updateDto)
        {
            Result resultado = _projectService.AtualizarProjeto(Id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarProjeto(int Id)
        {
            Result resultado = _projectService.DeletarProjeto(Id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
