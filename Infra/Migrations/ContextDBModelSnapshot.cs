﻿// <auto-generated />
using System;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Applicationcore.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("complement")
                        .HasMaxLength(20);

                    b.Property<string>("neightborhood")
                        .HasMaxLength(100);

                    b.Property<int>("number")
                        .HasMaxLength(10);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("Applicationcore.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birdDate")
                        .HasColumnName("birdDate")
                        .HasColumnType("datetime");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("identificationDocument");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Applicationcore.Entities.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("numero");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("Applicationcore.Entities.Adress", b =>
                {
                    b.HasOne("Applicationcore.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Applicationcore.Entities.Phone", b =>
                {
                    b.HasOne("Applicationcore.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
