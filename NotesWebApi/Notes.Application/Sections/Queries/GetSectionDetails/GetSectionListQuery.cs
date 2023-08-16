using MediatR;

namespace Notes.Application.Sections.Queries.GetSectionDetails
{
    public class GetSectionListQuery : IRequest<SectionListVm>
    {
        public Guid RoomId { get; set; }
    }
}
