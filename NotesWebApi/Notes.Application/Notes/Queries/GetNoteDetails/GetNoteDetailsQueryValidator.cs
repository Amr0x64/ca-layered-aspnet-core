using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(noteDetail => noteDetail.NoteId).NotEqual(Guid.Empty);
            RuleFor(noteDetail => noteDetail.UserId).NotEqual(Guid.Empty);
        }
    }
}
