using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNote => updateNote.NoteId).NotEqual(Guid.Empty);
            RuleFor(updateNote => updateNote.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNote => updateNote.Title).NotEmpty().MaximumLength(250);
        }
    }
}
