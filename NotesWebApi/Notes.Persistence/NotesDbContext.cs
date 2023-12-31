﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Interfaces;
using Notes.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using Notes.Persistence.EntityTypeConfigurations;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> notes { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Section> sections { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
