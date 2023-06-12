using Arpti.Domain.Entidades;
using Arpti.Infra.CrossCutting.Enumeradores;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arpti.Infra.Data.Context
{
    public class ArptiDbContext : IdentityDbContext
    {
        public ArptiDbContext(DbContextOptions<ArptiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Criando Admin
            var endereco = new Endereco("500", "89254-430", "Rau", "Jaraguá do Sul", "Santa Catarina");
            var admin = new Usuario("Rafael", "Costa", "30951669079", "ra.costa@catolicasc.edu.br", "Catolicasc", new DateTime(), endereco, TipoUsuario.Administrador);

            builder.Entity<Usuario>()
                .HasData(admin);
        }
    }
}
