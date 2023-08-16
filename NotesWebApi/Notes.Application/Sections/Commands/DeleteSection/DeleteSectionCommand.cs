using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommand : IRequest<Guid>
    {
        public Guid SectionId { get; set; }
        public Guid UserId { get; set; }
    }
}
