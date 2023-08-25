using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XpTest.Domain.Entities;

namespace XpTest.Infra.Data.Maps
{
    public sealed class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdClient").UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            builder.Property(x => x.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(14);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);
            builder.HasOne<Address>(x => x.Address).WithOne(c => c.Client).HasForeignKey<Address>(c => c.ClientId);
        }
    }
}
