using System.ComponentModel.DataAnnotations;

namespace COAE_PDF_BACKEND.Data.Dto
{
    public class CreateProjectDto
    {
        [Required(ErrorMessage="O campo nome é obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatorio")]
        public string Description { get; set; }
    }
}
