using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Sections.Queries.GetSectionDetails
{
    public class GetSectionListQueryHandler : IRequestHandler<GetSectionListQuery, SectionListVm>
    {
        private readonly INotesDbContext _db;
        public GetSectionListQueryHandler(INotesDbContext db) =>
            (_db) = (db);
        public async Task<SectionListVm> Handle(GetSectionListQuery request, CancellationToken cancellationToken)
        {
            var sections = await _db.sections.Include(n => n.Notes)
                .Where(s => s.IsActive && s.RoomId == request.RoomId)
                .ToListAsync(cancellationToken);

            SectionListVm vm = new SectionListVm() { Sections = sections };

            return vm;
        }
    }
}
