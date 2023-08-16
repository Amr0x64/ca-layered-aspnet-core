using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Rooms.Queries.GetRoomList
{
    public class RoomListVm
    {
        public IList<RoomLookupDto>? Rooms { get; set; }
    }
}
