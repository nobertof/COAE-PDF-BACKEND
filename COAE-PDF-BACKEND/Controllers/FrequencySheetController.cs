using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace COAE_PDF_BACKEND.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrequencySheetController : ControllerBase
    {
        private FrequencySheetService _frequencySheetService;

        public FrequencySheetController(FrequencySheetService frequencySheetService)
        {
            _frequencySheetService = frequencySheetService;
        }

        [HttpGet]
        public IActionResult PegarFrequencySheets()
        {
            return Ok(_frequencySheetService.PegarFrequencySheets());
        }
        [HttpGet("{id}")]
        public IActionResult PegarFrequencySheetPeloId(int id)
        {
            ReadFrequencySheetDto readDto = _frequencySheetService.PegarFrequencySheetPeloId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        [HttpPost]
        public IActionResult CriarFrequencySheet([FromBody] CreateFrequencySheetDto createDto)
        {
            ReadFrequencySheetDto readDto = _frequencySheetService.CriarFrequencySheet(createDto);
            return CreatedAtAction(nameof(PegarFrequencySheetPeloId),new { Id=readDto.Id }, readDto);
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarFrequencySheet(int id, [FromBody] UpdateFrequencySheetDto updateDto)
        {
            Result resultado = _frequencySheetService.AtualizarFrequencySheet(id, updateDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletarFrequencySheet(int id)
        {
            Result resultado = _frequencySheetService.DeletarFrequencySheet(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
