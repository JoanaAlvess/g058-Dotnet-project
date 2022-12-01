using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Infrastructure.Entregas
{
    internal class EntregaEntityTypeConfiguration : IEntityTypeConfiguration<Entrega>
    {
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {
            //builder.ToTable("Entregas", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);

            builder.HasOne<Armazem>().WithMany(a => a.Entregas).HasForeignKey(b => b._ArmazemId);
            builder.OwnsOne(b => b._DataEntrega);
            builder.OwnsOne(b => b._MassaEntrega);
            builder.OwnsOne(b => b._TempoColocar);
            builder.OwnsOne(b => b._TempoRetirar);

           /* builder.HasKey(b => b._DataEntrega);
            builder.HasKey(b => b._MassaEntrega);
            builder.HasKey(b => b._TempoColocar);
            builder.HasKey(b => b._TempoRetirar); */
            //builder.Property<bool>("_active").HasColumnName("Active");            
        }
    }
}
