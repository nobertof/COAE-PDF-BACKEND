using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace COAE_PDF_BACKEND.Models
{
    public class Project
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<AdvisorProject> RegisteredAdvisors { get; set; }
        [JsonIgnore]
        public virtual List<StudentProject> RegisteredStudents { get; set; }
        [JsonIgnore]
        public virtual List<FrequencySheet> FrequencySheets { get; set; }
    }
}
