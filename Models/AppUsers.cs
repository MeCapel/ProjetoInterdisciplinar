using Microsoft.AspNetCore.Identity;

namespace ProjetoInterdisciplinar.Models
{
    public class AppUsers : IdentityUser
    {
        public string Name { get; set; }
        public string Discriminator { get; set; }
        public bool Able { get; set; }
    }
}
