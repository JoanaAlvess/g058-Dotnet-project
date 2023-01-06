using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Armazens;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDDSample1.Infrastructure.Armazens
{
    public class ArmazemRepository : BaseRepository<Armazem,ArmazemId>, IArmazemRepository   {
      
        private readonly DDDSample1DbContext _context;
        private readonly DbSet<Armazem> _armazens;

        public ArmazemRepository(DDDSample1DbContext context):base(context.Armazens)
        {
            _context = context;
            _armazens = context.Armazens;
        }
        public async Task<IList<Armazem>> GetAllActiveAsync()
        {    
            return await this._armazens.Where(a => a.Active.Equals(true)).ToListAsync();
        }

        public async Task<Armazem> GetByLojaIdAsync(LojaId lojaId)
        {
            return await this._armazens.Where(a => a._LojaId.lojaId.Equals(lojaId.lojaId)).FirstAsync();
        }
    }
}
