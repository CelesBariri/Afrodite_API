using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ProfissionalMap : IEntityTypeConfiguration<ProfissionalModel>
    {
        public void Configure(EntityTypeBuilder<ProfissionalModel> builder)
        {
            builder.HasKey(x => x.ProfissionalId);
            builder.Property(x=> x.NomeProfissional).IsRequired().HasMaxLength(255);
            builder.Property(x => x.FotoProfissional).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoProfissionalId).IsRequired();
        }
    }
}
