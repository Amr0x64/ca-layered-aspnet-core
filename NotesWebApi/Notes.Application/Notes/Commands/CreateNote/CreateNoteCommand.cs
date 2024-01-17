using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        //Свойства необходимые для создания заметки
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }
        
        public Guid SectionId { get; set; }
    }
}
