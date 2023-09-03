using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly INotesDbContext _db;

        public UpdateRoomCommandHandler(INotesDbContext db) =>
            (_db) = (db);

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.rooms.FirstOrDefaultAsync(room => room.RoomId == request.RoomId, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            entity.Title = request.Title;

            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
