using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrequencyController : ControllerBase
    {
        private FrequencyService _frequencyService;

        public FrequencyController(FrequencyService frequencyService)
        {
            _frequencyService = frequencyService;
        }

        [HttpGet]
        public IActionResult PegarFrequencys()
        {
            return Ok(_frequencyService.PegarFrequencys());
        }
        [HttpGet("{id}")]
        public IActionResult PegarFrequencyPeloId(int id)
        {
            ReadFrequencyDto readDto = _frequencyService.PegarFrequencyPeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CriarFrequency([FromBody] CreateFrequencyDto createDto)
        {
            ReadFrequencyDto readDto = _frequencyService.CriarFrequency(createDto);
            return CreatedAtAction(nameof(PegarFrequencyPeloId), new { Id = readDto.Id }, readDto);

        }
        [HttpPut("{id}")]
        public IActionResult AtualizarFrequency(int id, [FromBody] UpdateFrequencyDto updateDto)
        {
            Result resultado = _frequencyService.AtualizarFrequency(id, updateDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarFrequency(int id)
        {
            Result resultado = _frequencyService.DeletarFrequency(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
