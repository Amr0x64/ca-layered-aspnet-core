using MediatR;
using Notes.Domain;

namespace Notes.Application.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommand : IRequest<Section>
    {
        public Guid SectionId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid UserId { get; set; }
    }
}
