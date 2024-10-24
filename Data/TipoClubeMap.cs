using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoClubeMap : IEntityTypeConfiguration<TipoClubeModel>
    {
        public void Configure(EntityTypeBuilder<TipoClubeModel> builder)
        {
            builder.HasKey(x => x.TipoClubeId);
            builder.Property(x => x.NomeTipoClube).IsRequired().HasMaxLength(255);
        }
    }
}
