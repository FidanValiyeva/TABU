﻿// <auto-generated />
using System;
using Babu.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Babu.Migrations
{
    [DbContext(typeof(BabuDbContext))]
    [Migration("20241224135844_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Babu.Entities.BannedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("BannedWord");
                });

            modelBuilder.Entity("Babu.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BannedWordCount")
                        .HasColumnType("int");

                    b.Property<int>("FailCount")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nchar(2)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SkipCount")
                        .HasColumnType("int");

                    b.Property<int?>("SuccessAnswer")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int?>("WrongAnswer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Babu.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Code = "az",
                            Icon = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Flag_of_Azerbaijan.svg/1200px-Flag_of_Azerbaijan.svg.png",
                            Name = "Azerbaycan"
                        });
                });

            modelBuilder.Entity("Babu.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nchar(2)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Babu.Entities.BannedWord", b =>
                {
                    b.HasOne("Babu.Entities.Word", "Word")
                        .WithMany("BannedWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Babu.Entities.Game", b =>
                {
                    b.HasOne("Babu.Entities.Language", "Language")
                        .WithMany("Games")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Babu.Entities.Word", b =>
                {
                    b.HasOne("Babu.Entities.Language", "Language")
                        .WithMany("Words")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Babu.Entities.Language", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("Babu.Entities.Word", b =>
                {
                    b.Navigation("BannedWords");
                });
#pragma warning restore 612, 618
        }
    }
}
