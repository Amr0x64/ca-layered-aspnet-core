using MediatR;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _db;

        public DeleteNoteCommandHandler(INotesDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.notes.FindAsync(new object[] { request.NoteId }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            _db.notes.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
