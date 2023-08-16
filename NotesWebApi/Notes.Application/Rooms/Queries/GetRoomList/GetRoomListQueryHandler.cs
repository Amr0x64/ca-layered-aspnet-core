using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Rooms.Queries.GetRoomList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, RoomListVm>
    {
        private readonly INotesDbContext _db;
        private readonly IMapper _mapper;
        public GetRoomListQueryHandler(INotesDbContext db, IMapper mapper) =>
            (_db, _mapper) = (db, mapper);
        public async Task<RoomListVm> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var roomsQuery = await _db.Rooms.Where(room => room.UserId == request.UserId && room.IsActive)
                .ProjectTo<RoomLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RoomListVm { Rooms = roomsQuery };
        }
    }
}
