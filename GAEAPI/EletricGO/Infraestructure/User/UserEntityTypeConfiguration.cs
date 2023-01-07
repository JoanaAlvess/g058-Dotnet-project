using DDDSample1.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDSample1.Infrastructure.Users
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("Families", SchemaNames.DDDSample1);
            
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b._Nome);
            builder.OwnsOne(b => b._Email);
            builder.OwnsOne(b => b._Password);
            builder.OwnsOne(b => b._Telefone);
            builder.OwnsOne(b => b._Role);
           
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}