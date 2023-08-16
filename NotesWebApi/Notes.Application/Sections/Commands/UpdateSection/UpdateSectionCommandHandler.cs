using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Runtime.CompilerServices;

namespace Notes.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Section>
    {
        private readonly INotesDbContext _db;
        public UpdateSectionCommandHandler(INotesDbContext db) =>
            (_db) = (db);
        public async Task<Section> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _db.Sections.Include(r => r.Room).
                FirstOrDefaultAsync(sec => sec.SectionId == request.SectionId, cancellationToken);
            
            if (section == null || section.Room.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Section), request.SectionId);  
            }

            section.Title = request.Title;
            section.Details = request.Details;

            await _db.SaveChangesAsync(cancellationToken);
            return section;
        }
    }
}
