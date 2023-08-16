using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly INotesDbContext _db;

        public DeleteRoomCommandHandler(INotesDbContext db) =>
        (_db) = (db);

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Rooms.FirstOrDefaultAsync(room => room.RoomId == request.RoomId);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }   

            entity.IsActive = false;
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
