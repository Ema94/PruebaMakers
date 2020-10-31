﻿// <auto-generated />
using System;
using Libreria.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Libreria.Db.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20201031174632_BooksStore")]
    partial class BooksStore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Libreria.Core.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditorialId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sopend")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SugestedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("EditorialId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Libreria.Core.Entities.Editorial", b =>
                {
                    b.Property<int>("EditorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EditorialId");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Libreria.Core.Entities.Book", b =>
                {
                    b.HasOne("Libreria.Core.Entities.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("EditorialId");
                });
#pragma warning restore 612, 618
        }
    }
}