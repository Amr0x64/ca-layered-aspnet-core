using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Sections.Commands.CreateSection
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Section>
    {
        private readonly INotesDbContext _db;

        public CreateSectionCommandHandler(INotesDbContext db) =>
            (_db) = (db);

        public async Task<Section> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var section = new Section
            {
                SectionId = new Guid(),
                Title = request.Title,
                Details = request.Details,
                CreationDate = DateTime.Now,
                IsActive = true,
                RoomId = request.RoomId
            };

            await _db.sections.AddAsync(section, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);

            return section;
        }
    }
}
