using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Infrastructure.Armazens
{
    internal class ArmazemEntityTypeConfiguration : IEntityTypeConfiguration<Armazem>
    {
        public void Configure(EntityTypeBuilder<Armazem> builder)
        {
            //builder.ToTable("Families", SchemaNames.DDDSample1);
           // builder.ToTable("Armazens");
            builder.HasKey(b => b.Id);
            builder.OwnsOne(b => b._Latitude);
            builder.OwnsOne(b => b._Longitude);
            builder.OwnsOne(b => b._Municipio);
            builder.OwnsOne(b => b._Endereco);
            builder.OwnsOne(b => b._LojaId);
            builder.OwnsOne(b => b._Designacao);
            builder.OwnsOne(b=> b._CidadeNo);
            builder.OwnsOne(b=> b._Altitude);
            
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}