using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoPlanoMap : IEntityTypeConfiguration<TipoPlanoModel>
    {
        public void Configure(EntityTypeBuilder<TipoPlanoModel> builder)
        {
            builder.HasKey(x => x.TipoPlanoId);
            builder.Property(x => x.NomeTipoPlano).IsRequired().HasMaxLength(255);
        }
    }
}
