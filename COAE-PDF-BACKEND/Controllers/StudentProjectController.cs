using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentProjectController : ControllerBase
    {
        private StudentProjectService _studentProjectService;

        public StudentProjectController(StudentProjectService studentProjectService)
        {
            _studentProjectService = studentProjectService;
        }

        [HttpGet]
        public IActionResult PegarStudentProjects()
        {
            return Ok(_studentProjectService.PegarStudentProjects());
        }
        [HttpGet("{id}")]
        public IActionResult PegarStudentProjectPeloId(int id)
        {
            ReadStudentProjectDto readDto = _studentProjectService.PegarStudentProjectPeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CriarStudentProject([FromBody] CreateStudentProjectDto createDto)
        {
            ReadStudentProjectDto readDto = _studentProjectService.CriarStudentProject(createDto);
            return CreatedAtAction(nameof(PegarStudentProjectPeloId),new { Id=readDto.Id}, readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarStudentProject(int id, [FromBody] UpdateStudentProjectDto updateDto)
        {
            Result resultado = _studentProjectService.AtualizarStudentProject(id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarStudentProject(int id)
        {
            Result resultado = _studentProjectService.DeletarStudentProject(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
