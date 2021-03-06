// <auto-generated />
using CrmWebApi.Domain.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrmWebApi.Domain.DatabaseContext.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211224122224_AddedDescriptionForProduct")]
    partial class AddedDescriptionForProduct
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

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAvailable = true,
                            Name = "Xiaomi Redmi Note 10",
                            Price = 7000m
                        },
                        new
                        {
                            Id = 2,
                            IsAvailable = true,
                            Name = "IPhone 13 Pro",
                            Price = 39000m
                        },
                        new
                        {
                            Id = 3,
                            IsAvailable = true,
                            Name = "Samsung Galaxy A12",
                            Price = 5500m
                        },
                        new
                        {
                            Id = 4,
                            IsAvailable = true,
                            Name = "Huawei Nova 8i",
                            Price = 10000m
                        },
                        new
                        {
                            Id = 5,
                            IsAvailable = true,
                            Name = "Oppo A74",
                            Price = 8900m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
