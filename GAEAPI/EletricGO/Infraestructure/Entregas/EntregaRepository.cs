using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Entregas;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDDSample1.Infrastructure.Entregas
{
    public class EntregaRepository : BaseRepository<Entrega,EntregaId>, IEntregaRepository   {

        private readonly DDDSample1DbContext _context;
        private readonly DbSet<Entrega> _entregas;
        
        public EntregaRepository(DDDSample1DbContext context):base(context.Entregas)
        {
            _context = context;
            _entregas = context.Entregas;
        }

        public async Task<IList<Entrega>> GetEntregasByArmazem(ArmazemId armazemId)
        {
            return await this._entregas.Where(e => e._ArmazemId.Equals(armazemId)).ToListAsync();
        }
    }
}