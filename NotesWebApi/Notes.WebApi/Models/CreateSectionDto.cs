using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Sections.Commands.CreateSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Models
{
    public class CreateSectionDto : IMapWith<CreateSectionCommand>
    {
        public string Title { get; set; }
        public string? Details { get; set; }
        public Guid RoomId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSectionDto, CreateSectionCommand>()
                .ForMember(secCom => secCom.Title,
                    opt => opt.MapFrom(sec => sec.Title))
                .ForMember(secCom => secCom.Details,
                    opt => opt.MapFrom(sec => sec.Details))
                .ForMember(secCom => secCom.RoomId,
                    opt => opt.MapFrom(sec => sec.RoomId));

        }
    }
}
