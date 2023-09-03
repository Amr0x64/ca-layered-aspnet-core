using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> notes { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Section> sections { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
