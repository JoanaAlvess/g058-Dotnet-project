using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using System.Net.Http;

namespace DDDSample1.Domain.Armazens
{
    public class ArmazemService
    {   
        private static readonly HttpClient client = new HttpClient();
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArmazemRepository _repo;

        public ArmazemService(IUnitOfWork unitOfWork, IArmazemRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

          public async Task<List<ArmazemDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
         List<ArmazemDto> listDto = list.ConvertAll<ArmazemDto>(arm => 
                new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude)); 

            return listDto;
        }

        public async Task<ArmazemDto> GetByIdAsync(ArmazemId id)
        {
            var arm = await this._repo.GetByIdAsync(id);
            
            if(arm == null)
                return null;

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude);
        }
    
        public async Task<ArmazemDto> AddAsync(CreatingArmazemDto dto)
        {
            var arm = new Armazem(dto.Longitude, dto.Latitude, dto.Endereco, dto.Designacao, dto.Municipio, dto.LojaId);

            await this._repo.AddAsync(arm);

            await this._unitOfWork.CommitAsync();

            var values = new Dictionary<string, string>
            {
            { "thing1", "hello" },
            { "thing2", "world" }
            };

             var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude);
        }

        public async Task<ArmazemDto> UpdateAsync(ArmazemDto dto)
        {
            var arm = await this._repo.GetByIdAsync(new ArmazemId(dto.Id)); 

            if (arm == null)
                return null;   

            // change all field
            arm.ChangeLongitude(dto.Longitude);
            arm.ChangeLatitude(dto.Latitude);
            arm.ChangeEndereco(dto.Endereco);
            arm.ChangeDesignacao(dto.Designacao);
            arm.ChangeMunicipio(dto.Municipio);
            arm.ChangeLojaId(dto.LojaId);

            await this._unitOfWork.CommitAsync();

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude);
        }

        public async Task<ArmazemDto> InactivateAsync(ArmazemId id)
        {
            var arm = await this._repo.GetByIdAsync(id); 

            if (arm == null)
                return null;   

            // change all fields
            arm.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude);
        }

         public async Task<ArmazemDto> DeleteAsync(ArmazemId id)
        {
            var arm = await this._repo.GetByIdAsync(id); 

            if (arm == null)
                return null;   

            if (arm.Active)
                throw new BusinessRuleValidationException("It is not possible to delete an active armazem.");
            
            this._repo.Remove(arm);
            await this._unitOfWork.CommitAsync();

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude);
        }

    }
}