using DDDSample1.Domain.Armazens;
using DDDSample1.Infrastructure.Shared;

namespace DDDSample1.Infrastructure.Armazens
{
    public class ArmazemRepository : BaseRepository<Armazem,ArmazemId>, IArmazemRepository   {
      
        public ArmazemRepository(DDDSample1DbContext context):base(context.Armazens)
        {
            
        }

    }
}