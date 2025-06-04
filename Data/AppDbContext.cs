using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoInterdisciplinar.Models;

namespace ProjetoInterdisciplinar.Data
{
    public class AppDbContext : IdentityDbContext<AppUsers>
    {
        public DbSet<Vaga> Vagas { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUsers>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<PFUser>("PF")
                .HasValue<PJUser>("PJ")
                .HasValue<AppUsers>("Admin");
        }
    }
}
