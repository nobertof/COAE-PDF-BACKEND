using COAE_PDF_BACKEND.Models;
using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class ReadStudentProjectDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }

        public string Status { get; set; }
    }
}
