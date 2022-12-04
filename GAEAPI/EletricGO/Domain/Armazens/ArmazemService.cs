using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System;

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
            client.DefaultRequestHeaders
      .Accept
      .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

          public async Task<List<ArmazemDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            
         List<ArmazemDto> listDto = list.ConvertAll<ArmazemDto>(arm => 
                new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no)); 

            return listDto;
        }

        public async Task<ArmazemDto> GetByIdAsync(ArmazemId id)
        {
            var arm = await this._repo.GetByIdAsync(id);
            
            if(arm == null)
                return null;

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
        }
    
        public async Task<ArmazemDto> AddAsync(CreatingArmazemDto dto)
        {
            var arm = new Armazem(dto.Longitude, dto.Latitude, dto.Endereco, dto.Designacao, dto.Municipio, dto.LojaId,dto.CidadeNo);

            await this._repo.AddAsync(arm);

            await this._unitOfWork.CommitAsync();

            var Id = arm.Id.AsGuid();
            var armd = new ArmazemDto(Id, arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
            var armd1 = new ArmazemDtoRequest(Id, arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
           
            var json = JsonConvert.SerializeObject(armd1);
            var data = new StringContent(json,Encoding.UTF8,"application/json");

            var url = "https://vs-gate.dei.isep.ipp.pt:30272/api/Armazens";
            
            var response = await client.PostAsync(url,data);

            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine("-------------------------------------"+result+"----------------------------------------");
            
            Console.WriteLine("oooooo"+json+"oooooo");


            return armd;
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

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
        }

        public async Task<ArmazemDto> InactivateAsync(ArmazemId id)
        {
            var arm = await this._repo.GetByIdAsync(id); 

            if (arm == null)
                return null;   

            // change all fields
            arm.MarkAsInative();
            
            await this._unitOfWork.CommitAsync();

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
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

            return new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude,arm._CidadeNo.no);
        }

    }
}