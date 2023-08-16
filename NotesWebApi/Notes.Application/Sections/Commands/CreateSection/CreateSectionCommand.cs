using MediatR;
using Notes.Domain;

namespace Notes.Application.Sections.Commands.CreateSection
{
    public class CreateSectionCommand : IRequest<Section>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid RoomId { get; set; }
    }
}
