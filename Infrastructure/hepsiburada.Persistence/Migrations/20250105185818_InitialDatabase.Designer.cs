﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hepsiburada.Persistence.Context;

#nullable disable

namespace hepsiburada.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250105185818_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(2663),
                            IsDeleted = false,
                            Name = "Industrial"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(2752),
                            IsDeleted = false,
                            Name = "Toys & Music"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(2760),
                            IsDeleted = false,
                            Name = "Toys"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(2765),
                            IsDeleted = true,
                            Name = "Toys"
                        });
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(5577),
                            IsDeleted = false,
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(5579),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentId = 2,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(5574),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 56, DateTimeKind.Local).AddTicks(5575),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 2
                        });
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 62, DateTimeKind.Local).AddTicks(9424),
                            Description = "Lambadaki gül laudantium nesciunt çıktılar.",
                            IsDeleted = false,
                            Title = "Sokaklarda."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 62, DateTimeKind.Local).AddTicks(9507),
                            Description = "Ve eaque sokaklarda dolore ad quae deleniti.",
                            IsDeleted = false,
                            Title = "Sunt aliquid."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 62, DateTimeKind.Local).AddTicks(9538),
                            Description = "Consequuntur sokaklarda vel çakıl.",
                            IsDeleted = true,
                            Title = "Orta."
                        });
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 65, DateTimeKind.Local).AddTicks(7002),
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Discount = 7.024241222444480m,
                            IsDeleted = false,
                            Price = 648.09m,
                            Title = "Unbranded Concrete Mouse"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 4,
                            CreatedDate = new DateTime(2025, 1, 5, 21, 58, 18, 65, DateTimeKind.Local).AddTicks(7034),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Discount = 2.629943228849720m,
                            IsDeleted = false,
                            Price = 949.41m,
                            Title = "Licensed Plastic Gloves"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("hepsiburada.domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hepsiburada.domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Detail", b =>
                {
                    b.HasOne("hepsiburada.domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Product", b =>
                {
                    b.HasOne("hepsiburada.domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("hepsiburada.domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
