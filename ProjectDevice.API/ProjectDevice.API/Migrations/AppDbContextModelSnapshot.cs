﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectDevice.API.Context;

#nullable disable

namespace ProjectDevice.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectDevice.API.Models.Device", b =>
                {
                    b.Property<string>("DeviceId")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("deviceId");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<string>("DocumentPath")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("document_path");

                    b.Property<string>("FotoPath")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("foto_path");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("DeviceId");

                    b.ToTable("devices");
                });
#pragma warning restore 612, 618
        }
    }
}
