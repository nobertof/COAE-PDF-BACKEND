using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Models
{
    public class Frequency
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="A data inicial é obrigatoria")]
        public DateTime InitialDate { get; set; }
        [Required(ErrorMessage = "A data final é obrigatoria")]
        public DateTime FinalDate { get; set; }

        public int FrequencySheetId { get; set; }
        [JsonIgnore]
        public virtual FrequencySheet FrequencySheet { get; set; }
    }
}
