using COAE_PDF_BACKEND.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class ReadFrequencySheetDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo ano é obrigatorio")]
        public int Year { get; set; }
        [Required(ErrorMessage = "O campo mês é obrigatorio")]
        public int Month { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual List<Frequency> Frequencies { get; set; }
    }
}
