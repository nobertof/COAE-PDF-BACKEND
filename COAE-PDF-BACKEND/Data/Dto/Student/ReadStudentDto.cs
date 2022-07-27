using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class ReadStudentDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int AcessoId { get; set; }
        public string Matricula { get; set; }

        public object Projects { get; set; }
    }
}
