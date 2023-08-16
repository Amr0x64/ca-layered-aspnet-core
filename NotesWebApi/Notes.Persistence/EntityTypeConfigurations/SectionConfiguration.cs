using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(section => section.SectionId);
            builder.HasIndex(section => section.SectionId).IsUnique();
            builder.Property(sec => sec.Title).HasMaxLength(250);
            builder.Property(sec => sec.Details).HasMaxLength(500);
        }
    }
}
