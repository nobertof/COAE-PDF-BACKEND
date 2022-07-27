using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Models
{
    public class AdvisorProject
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
    }
}
