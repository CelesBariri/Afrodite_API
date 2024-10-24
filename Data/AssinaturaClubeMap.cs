using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AssinaturaClubeMap : IEntityTypeConfiguration<AssinaturaClubeModel>
    {
        public void Configure(EntityTypeBuilder<AssinaturaClubeModel> builder)
        {
            builder.HasKey(x => x.AssinaturaClubeId);
            builder.Property(x=> x.ClienteId).IsRequired();
            builder.Property(x => x.ClubeId).IsRequired();
        }
    }
}
