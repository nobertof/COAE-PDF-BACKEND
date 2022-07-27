using System;
using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class UpdateFrequencyDto
    {
        [Required(ErrorMessage = "A data inicial é obrigatoria")]
        public DateTime InitialDate { get; set; }
        [Required(ErrorMessage = "A data final é obrigatoria")]
        public DateTime FinalDate { get; set; }

        public int FrequencySheetId { get; set; }
    }
}
