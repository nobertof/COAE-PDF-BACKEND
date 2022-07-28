using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace COAE_CADASTRO.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Mensagem(IEnumerable<string> recipient, string subject, int usuarioId, string codigo)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress(d)));
            Subject = subject;
            Content = $"http://localhost:6000/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={codigo}";
        }
    }
}
