﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notes.Persistence;

#nullable disable

namespace Notes.Persistence.Migrations
{
    [DbContext(typeof(NotesDbContext))]
    [Migration("20230511104719_NoteMigr")]
    partial class NoteMigr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Notes.Domain.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentNoteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("NoteId");

                    b.HasIndex("NoteId")
                        .IsUnique();

                    b.HasIndex("ParentNoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Notes.Domain.Note", b =>
                {
                    b.HasOne("Notes.Domain.Note", "ParentNote")
                        .WithMany()
                        .HasForeignKey("ParentNoteId");

                    b.Navigation("ParentNote");
                });
#pragma warning restore 612, 618
        }
    }
}