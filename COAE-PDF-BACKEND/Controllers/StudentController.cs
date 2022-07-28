using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController:ControllerBase
    {
        private StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult PegarEstudantes()
        {
            return Ok(_studentService.PegarEstudantes());
        }
        [HttpGet("{id}")]
        public IActionResult PegarEstudantePeloId(int id)
        {
            ReadStudentDto readDto = _studentService.PegarEstudantePeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CadastrarEstudante([FromBody] CreateStudentDto createDto)
        {
            ReadStudentDto readDto = _studentService.CadastrarEstudante(createDto);
            return CreatedAtAction(nameof(PegarEstudantePeloId), new { Id = readDto.Id }, readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarEstudante(int id, [FromBody] CreateStudentDto updateDto)
        {
            Result resultado = _studentService.AtualizarEstudante(id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarEstudante(int id)
        {
            Result resultado = _studentService.DeletarProjeto(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
