using Arpti.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arpti.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(Constantes.Constantes.Tabelas.Usuario, Constantes.Constantes.Schemas.Identidade);

            builder.Property(usuario => usuario.Nome).HasMaxLength(250);
            builder.Property(usuario => usuario.Sobrenome).HasMaxLength(250);
            builder.Property(usuario => usuario.Email).HasMaxLength(250);
            builder.Property(usuario => usuario.Senha).HasMaxLength(250);
            builder.Property(usuario => usuario.CPFCNPJ).HasMaxLength(18);

            builder.HasOne(usuario => usuario.Endereco);
        }
    }
}
