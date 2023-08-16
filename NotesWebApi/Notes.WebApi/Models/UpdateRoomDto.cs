using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Rooms.Commands.UpdateRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Models
{
    public class UpdateRoomDto : IMapWith<UpdateRoomCommand>
    {
        public Guid RoomId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRoomDto, UpdateRoomCommand>()
                .ForMember(roomCom => roomCom.Title,
                    opt => opt.MapFrom(room => room.Title))
                .ForMember(roomCom => roomCom.RoomId,
                    opt => opt.MapFrom(room => room.RoomId));
        }
    }
}
