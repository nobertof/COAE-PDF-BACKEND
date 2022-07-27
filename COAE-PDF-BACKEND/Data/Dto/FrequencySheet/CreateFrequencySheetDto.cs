
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class CreateFrequencySheetDto
    {
        [Required(ErrorMessage = "O campo ano é obrigatorio")]
        public int Year { get; set; }
        [Required(ErrorMessage = "O campo mês é obrigatorio")]
        public int Month { get; set; }

        public int ProjectId { get; set; }
    }
}
