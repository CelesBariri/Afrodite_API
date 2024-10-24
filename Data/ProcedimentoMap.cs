using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ProcedimentoMap : IEntityTypeConfiguration<ProcedimentoModel>
    {
        public void Configure(EntityTypeBuilder<ProcedimentoModel> builder)
        {
            builder.HasKey(x => x.ProcedimentoId);
            builder.Property(x=> x.NomeProcedimento).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ValorProcedimento).IsRequired();
        }
    }
}
