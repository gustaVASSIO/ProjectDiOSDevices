﻿// <auto-generated />
using System;
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
                    b.Property<Guid>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80)
                        .HasColumnType("char(80)")
                        .HasColumnName("device_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("DocumentPath")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("document_path");

                    b.Property<string>("FotoPath")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("foto_path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("DeviceId");

                    b.ToTable("devices");
                });

            modelBuilder.Entity("ProjectDevice.API.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subscription_id");

                    b.Property<string>("Description")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("description");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("char(80)")
                        .HasColumnName("device_id");

                    b.Property<string>("Title")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("title");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("DeviceId");

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("ProjectDevice.API.Models.Subscription", b =>
                {
                    b.HasOne("ProjectDevice.API.Models.Device", "Device")
                        .WithMany("Subscriptions")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ProjectDevice.API.Models.Device", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
