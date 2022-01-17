﻿// <auto-generated />
using System;
using CrmWebApi.Domain.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrmWebApi.Domain.DatabaseContext.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220115140148_ProductCategoryNameFieldConstraints")]
    partial class ProductCategoryNameFieldConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrmWebApi.Domain.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            IsAvailable = true,
                            Name = "Xiaomi Redmi Note 10",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            IsAvailable = true,
                            Name = "IPhone 13 Pro",
                            Price = 39000m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            IsAvailable = true,
                            Name = "Samsung Galaxy A12",
                            Price = 5500m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            IsAvailable = true,
                            Name = "Huawei Nova 8i",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            IsAvailable = true,
                            Name = "Oppo A74",
                            Price = 8900m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            IsAvailable = true,
                            Name = "HP EliteBook",
                            Price = 45000m
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            IsAvailable = true,
                            Name = "ASUS ZenBook",
                            Price = 35000m
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            IsAvailable = true,
                            Name = "Samsung QE55Q60AAUXUA",
                            Price = 36000m
                        });
                });

            modelBuilder.Entity("CrmWebApi.Domain.Core.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Smartphone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 3,
                            Name = "TV"
                        });
                });

            modelBuilder.Entity("CrmWebApi.Domain.Core.Product", b =>
                {
                    b.HasOne("CrmWebApi.Domain.Core.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CrmWebApi.Domain.Core.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
