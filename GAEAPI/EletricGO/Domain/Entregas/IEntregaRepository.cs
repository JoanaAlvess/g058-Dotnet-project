using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas
{
    public interface IEntregaRepository: IRepository<Entrega, EntregaId>
    {
        public Task<IList<Entrega>> GetEntregasByArmazem(ArmazemId armazemId);
    }
}