using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Modelos;

namespace Prova.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModelo>
    {
        public void Configure(EntityTypeBuilder<UsuarioModelo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
