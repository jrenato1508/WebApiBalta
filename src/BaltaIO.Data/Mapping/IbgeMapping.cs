using BaltaIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaIO.Data.Mapping
{
    public class IbgeMapping : IEntityTypeConfiguration<IBGE>
    {
        public void Configure(EntityTypeBuilder<IBGE> builder)
        {
            builder.HasKey(b => b.id);

            builder.Property(b => b.City)
                .IsRequired()
                .HasColumnType("char(2)");

            builder.Property(b => b.State)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.ToTable("IBGE");
        }
    }
}
