﻿// <auto-generated />
using FakeAmazon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FakeAmazon.Migrations
{
    [DbContext(typeof(FakeAmazonDbContext))]
    partial class FakeAmazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FakeAmazon.Models.Project", b =>
            {
                b.Property<int>("BookId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("AuthorFirst")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("AuthorLast")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("AuthorMiddle")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Category")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Classification")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ISBN")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Pages")
                    .HasColumnType("int");

                b.Property<double>("Price")
                    .HasColumnType("float");

                b.Property<string>("Publisher")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("BookId");

                b.ToTable("Projects");
            });
#pragma warning restore 612, 618
        }
    }
}