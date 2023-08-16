using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Sections.Commands.CreateSection;
using Notes.Application.Sections.Commands.UpdateSection;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WebApi.Models
{
    public class UpdateSectionDto : IMapWith<UpdateSectionCommand>
    {
        public Guid SectionId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSectionDto, UpdateSectionCommand>()
                .ForMember(secCom => secCom.Title,
                    opt => opt.MapFrom(sec => sec.Title))
                .ForMember(secCom => secCom.Details,
                    opt => opt.MapFrom(sec => sec.Details))
                .ForMember(secCom => secCom.SectionId,
                    opt => opt.MapFrom(sec => sec.SectionId));

        }
    }
}
