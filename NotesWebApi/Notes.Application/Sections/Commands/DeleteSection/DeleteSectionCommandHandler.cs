using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Guid>
    {
        private readonly INotesDbContext _db;

        public DeleteSectionCommandHandler(INotesDbContext db) =>
            (_db) = (db);

        public async Task<Guid> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _db.sections.Include(r => r.Room).Select(r => new Section { SectionId = r.SectionId, 
                IsActive = r.IsActive, Room = r.Room})
                .FirstOrDefaultAsync(sec => sec.SectionId == request.SectionId, cancellationToken);

            if (section == null || section.Room.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Section), request.SectionId);
            }

            section.IsActive = false;
            await _db.SaveChangesAsync(cancellationToken);

            return section.SectionId;
        }
    }
}
