using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Models
{
    public class Advisor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int AcessoId { get; set; }
        public string Matricula { get; set; }
        [JsonIgnore]
        public virtual List<AdvisorProject> Projects { get; set; }
    }
}
