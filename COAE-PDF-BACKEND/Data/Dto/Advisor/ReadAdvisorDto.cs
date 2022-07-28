using COAE_PDF_BACKEND.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class ReadAdvisorDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AcessoId { get; set; }
        public string Matricula { get; set; }
        public virtual List<AdvisorProject> Projects { get; set; }
    }
}
