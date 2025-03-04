﻿// <auto-generated />
using Bible_Search.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bible_Search.Migrations
{
    [DbContext(typeof(BibleDbContext))]
    partial class BibleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Bible_Search.Models.BibleVerse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Book")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<string>("Testament")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VerseNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BibleVerses");
                });
#pragma warning restore 612, 618
        }
    }
}
