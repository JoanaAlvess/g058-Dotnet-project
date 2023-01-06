using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens
{
    public interface IArmazemRepository: IRepository<Armazem, ArmazemId>
    {
        public Task<IList<Armazem>> GetAllActiveAsync();
        public Task<Armazem> GetByLojaIdAsync(LojaId lojaId);
    }
}