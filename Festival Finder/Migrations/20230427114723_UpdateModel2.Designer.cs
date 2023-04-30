﻿// <auto-generated />
using System;
using Festival_Finder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Festival_Finder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230427114723_UpdateModel2")]
    partial class UpdateModel2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Festival_Finder.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Festival_Finder.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("FestivalId");

                    b.HasIndex("LocationId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Festival_Finder.Models.Festival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("LocationId");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("Festival_Finder.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Festival_Finder.Models.AppUser", b =>
                {
                    b.HasOne("Festival_Finder.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Festival_Finder.Models.Artist", b =>
                {
                    b.HasOne("Festival_Finder.Models.AppUser", null)
                        .WithMany("Artists")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Festival_Finder.Models.Festival", "Festival")
                        .WithMany("Artist")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Festival_Finder.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Festival");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Festival_Finder.Models.Festival", b =>
                {
                    b.HasOne("Festival_Finder.Models.AppUser", null)
                        .WithMany("Festivals")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Festival_Finder.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Festival_Finder.Models.AppUser", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Festivals");
                });

            modelBuilder.Entity("Festival_Finder.Models.Festival", b =>
                {
                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
