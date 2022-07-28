using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Models
{
    public class StudentProject
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public int StudentId { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectId { get; set; }

        public string Status { get; set; }

    }
}
