using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public class Section
    {
        public Guid SectionId { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }    
        public DateTime CreationDate { get; set; }  
        public bool IsActive { get; set; }

        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public List<Note>? Notes { get; set; } = new List<Note>();
    }
}
