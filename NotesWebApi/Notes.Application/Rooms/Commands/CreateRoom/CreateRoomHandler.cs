using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateRoomHandler(INotesDbContext dbContext) =>
            (_dbContext) = (dbContext);

        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room
            {
                RoomId = new Guid(),
                Title = request.Title,
                CreationDate = DateTime.Now,
                IsActive = true,
                UserId = request.UserId
            };

            await _dbContext.rooms.AddAsync(room, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return room.RoomId;
        }
    }
}
