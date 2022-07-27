using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Models
{
    public class FrequencySheet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="O campo ano é obrigatorio")]
        public int Year { get; set; }
        [Required(ErrorMessage = "O campo mês é obrigatorio")]
        public int Month { get; set; }

        public int ProjectId { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }
        [JsonIgnore]

        public virtual List<Frequency> Frequencies { get; set; }
    }
}
