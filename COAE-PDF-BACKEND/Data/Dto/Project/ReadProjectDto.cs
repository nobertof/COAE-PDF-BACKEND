using COAE_PDF_BACKEND.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class ReadProjectDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public object RegisteredAdvisors { get; set; }
        public object RegisteredStudents { get; set; }
        public object FrequencySheets { get; set; }

    }
}
