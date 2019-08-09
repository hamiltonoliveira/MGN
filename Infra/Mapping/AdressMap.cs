using Applicationcore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class AdressMap : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress");
            builder.Property(x => x.street).HasMaxLength(100);
            builder.Property(x => x.number).HasMaxLength(10);
            builder.Property(x => x.complement).HasMaxLength(20);
            builder.Property(x => x.neightborhood).HasMaxLength(100);
            builder.Property(x => x.city).HasMaxLength(50);
            builder.Property(x => x.state).HasMaxLength(2);
        }
    }
}
