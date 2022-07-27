using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int AcessoId { get; set; }
        public string Matricula { get; set; }

        public virtual List<StudentProject> Projects { get; set; }

    }
}
