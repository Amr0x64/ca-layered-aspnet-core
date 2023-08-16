using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Rooms.Queries.GetRoomList
{
    public class RoomLookupDto : IMapWith<Room>
    {
        public Guid RoomId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomLookupDto>()
                .ForMember(roomDto => roomDto.RoomId,
                    opt => opt.MapFrom(room => room.RoomId))
                .ForMember(roomDto => roomDto.Title,
                    opt => opt.MapFrom(room => room.Title));
        }

    }
}
