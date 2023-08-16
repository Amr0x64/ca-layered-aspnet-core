using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }   
    }
}
