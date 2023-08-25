using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpTest.Domain.Entities;

namespace XpTest.Infra.Data.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.Property(x => x.Id).HasColumnName("IdAddress").UseIdentityColumn();
            builder.Property(x => x.Street).HasColumnName("Street").IsRequired().HasMaxLength(255);
            builder.Property(x => x.StreetNumber).HasColumnName("StreetNumber").IsRequired().HasMaxLength(5);
            builder.Property(x => x.City).HasColumnName("City").IsRequired().HasMaxLength(100);
        }
    }
}
