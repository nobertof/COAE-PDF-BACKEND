using Microsoft.AspNetCore.Identity;

namespace COAE_CADASTRO.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
