using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ClubeMap : IEntityTypeConfiguration<ClubeModel>
    {
        public void Configure(EntityTypeBuilder<ClubeModel> builder)
        {
            builder.HasKey(x => x.ClubeId);
            builder.Property(x=> x.NomeClube).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FotoClube).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoClubeId).IsRequired();
            builder.Property(x => x.TipoPlanoId).IsRequired();
            builder.Property(x => x.DetalhesClube).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ValorClube).IsRequired();
        }
    }
}
