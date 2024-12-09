﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreyChallenge.Context;

#nullable disable

namespace StoreyChallenge.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StoreyChallenge.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Iluminación"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Refrigeración"
                        });
                });

            modelBuilder.Entity("StoreyChallenge.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Element = "Lámpara Led de 5w",
                            IsDeleted = false,
                            Value = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Element = "Lámpara Led de 10w",
                            IsDeleted = false,
                            Value = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Element = "Lámpara Incandescente 40w",
                            IsDeleted = false,
                            Value = 40
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Element = "Lámpara Incandescente de 100w",
                            IsDeleted = false,
                            Value = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Element = "Lámpara Incandescente de 200w",
                            IsDeleted = false,
                            Value = 200
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Element = "Heladera",
                            IsDeleted = false,
                            Value = 1000
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Element = "Freezer",
                            IsDeleted = false,
                            Value = 1500
                        });
                });

            modelBuilder.Entity("StoreyChallenge.Models.Item", b =>
                {
                    b.HasOne("StoreyChallenge.Models.Category", "Categories")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("StoreyChallenge.Models.Category", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}