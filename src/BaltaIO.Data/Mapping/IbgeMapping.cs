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

            builder.Property(b => b.Codigo)
                .IsRequired()
                .HasColumnType("nvarchar(255)");

            builder.Property(b => b.UF)
                .IsRequired()
                .HasColumnType("nvarchar(255)");

            builder.Property(b => b.Cidade)
                .IsRequired()
                .HasColumnType("nvarchar(255)");

            builder.ToTable("IBGE");
        }
    }
}
