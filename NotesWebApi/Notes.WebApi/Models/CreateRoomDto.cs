using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Rooms.Commands.CreateRoom;

namespace Notes.WebApi.Models
{
    public class CreateRoomDto : IMapWith<CreateRoomCommand>
    {
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRoomDto, CreateRoomCommand>()
                .ForMember(roomCommand => roomCommand.Title,
                    opt => opt.MapFrom(room => room.Title));
        }
    }
}
