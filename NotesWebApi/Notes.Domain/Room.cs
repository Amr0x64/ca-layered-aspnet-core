using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
    }
}
