using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
    }
}
