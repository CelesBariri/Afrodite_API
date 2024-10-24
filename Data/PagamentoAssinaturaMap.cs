using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PagamentoAssinaturaMap : IEntityTypeConfiguration<PagamentoAssinaturaModel>
    {
        public void Configure(EntityTypeBuilder<PagamentoAssinaturaModel> builder)
        {
            builder.HasKey(x => x.PagamentoAssinaturaId);
            builder.Property(x => x.AssinaturaClubeId).IsRequired();
            builder.Property(x => x.FormaPagamentoId).IsRequired();
        }
    }
}
