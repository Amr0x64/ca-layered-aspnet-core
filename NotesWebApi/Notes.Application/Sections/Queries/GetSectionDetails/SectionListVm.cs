using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Sections.Queries.GetSectionDetails
{
    public class SectionListVm
    {
        public IList<Section>? Sections { get; set; }
    }
}
