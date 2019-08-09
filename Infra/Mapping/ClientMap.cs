using Applicationcore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mapping
{
    class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.name).HasMaxLength(100);
            builder.Property(x => x.identificationDocument);
            builder.Property(x => x.birdDate).HasColumnName("birdDate").HasColumnType("datetime");
            builder.Property(x => x.gender).HasMaxLength(10);
            builder.Property(x => x.gender).HasMaxLength(10);
        }
    }
}
