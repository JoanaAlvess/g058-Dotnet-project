using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazens;
using System.Linq;

namespace DDDSample1.Domain.Entregas
{
    public class EntregaService
    {
    
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntregaRepository _repo;

        public EntregaService(IUnitOfWork unitOfWork, IEntregaRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public async Task<List<EntregaDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
            List<EntregaDto> listDto = list.ConvertAll<EntregaDto>(ent => 
                new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar)); 

            return listDto;
        }

        public async Task<EntregaDto> GetByIdAsync(EntregaId id)
        {
            var ent = await this._repo.GetByIdAsync(id);
            
            if(ent == null)
                return null;

            return new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar);
        }

        public async Task<List<EntregaDto>> GetByArmazemId(ArmazemId armazemId){
            var list = await this._repo.GetEntregasByArmazem(armazemId);

            List<EntregaDto> listDto = list.ToList<Entrega>().ConvertAll<EntregaDto>(ent => 
                new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar)); 

            return listDto;
        }

        public async Task<EntregaDto> AddAsync(CreatingEntregaDto dto)
        {
            var ent = new Entrega(dto.Armazem_Id, dto.DataEntrega, dto.MassaEntrega, dto.TempoColocar, dto.TempoRetirar);

            await this._repo.AddAsync(ent);

            await this._unitOfWork.CommitAsync();

            return new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar);
        }

        public async Task<EntregaDto> UpdateAsync(EntregaDto dto)
        {
            var ent = await this._repo.GetByIdAsync(new EntregaId(dto.Id)); 

            if (ent == null)
                return null;   

            // change all field
            ent.ChangeArmazemEntrega(dto.Armazem_Id);
            ent.ChangeDataEntrega(dto.DataEntrega);
            ent.ChangeMassaEntrega(dto.MassaEntrega);
            ent.ChangeTempoColocar(dto.TempoColocar);
            ent.ChangeTempoRetirar(dto.TempoRetirar);

            await this._unitOfWork.CommitAsync();

            return new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar);
        }

        public async Task<EntregaDto> InactivateAsync(EntregaId id)
        {
            var ent = await this._repo.GetByIdAsync(id); 

            if (ent == null)
                return null;   

            // change all fields
            ent.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new EntregaDto( ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar,ent._TempoRetirar._tempoRetirar);
        }

         public async Task<EntregaDto> DeleteAsync(EntregaId id)
        {
            var ent = await this._repo.GetByIdAsync(id); 

            if (ent == null)
                return null;   

            if (ent.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active entrega.");
            
            this._repo.Remove(ent);
            await this._unitOfWork.CommitAsync();

            return new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar);
        }
    }
}