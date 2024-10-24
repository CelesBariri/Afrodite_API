using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoProcedimentoMap : IEntityTypeConfiguration<TipoProcedimentoModel>
    {
        public void Configure(EntityTypeBuilder<TipoProcedimentoModel> builder)
        {
            builder.HasKey(x => x.TipoProcedimentoId);
            builder.Property(x=> x.NomeTipoProcedimento).IsRequired().HasMaxLength(255);
        }
    }
}
