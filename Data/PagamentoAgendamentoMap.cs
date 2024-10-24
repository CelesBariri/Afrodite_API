using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PagamentoAgendamentoMap : IEntityTypeConfiguration<PagamentoAgendamentoModel>
    {
        public void Configure(EntityTypeBuilder<PagamentoAgendamentoModel> builder)
        {
            builder.HasKey(x => x.PagamentoAgendamentoId);
            builder.Property(x => x.AgendamentoId).IsRequired();
            builder.Property(x => x.FormaPagamentoId).IsRequired();
        }
    }
}
