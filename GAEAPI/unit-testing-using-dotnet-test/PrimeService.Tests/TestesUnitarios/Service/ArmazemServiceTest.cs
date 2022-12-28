using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;
using Moq;

namespace Tests.TestesUnitarios.Service
{
    public class ArmazemServiceTest
    {
        private readonly Mock<IUnitOfWork> _unit;
        private readonly Mock<IArmazemRepository> _repo;
        private readonly ArmazemService _service;
        private CreatingArmazemDto cdto;
        private DDDSample1.Domain.Armazens.Armazem arm;
        private ArmazemDto adto;

        public ArmazemServiceTest()
        {
            _unit = new Mock<IUnitOfWork>();
            _repo = new Mock<IArmazemRepository>();
            _service = new ArmazemService(_unit.Object, _repo.Object);
            _unit.Setup(x => x.CommitAsync()).Returns(Task.FromResult(1));
            
            cdto = new CreatingArmazemDto("Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48,5,40);
            //Guid id = new Guid();
            arm = new DDDSample1.Domain.Armazens.Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01",5,40);
           
            adto = new ArmazemDto(Guid.NewGuid(),"Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48,5,true,40);
        }

        [Fact]
        public void GetAllAsyncTest()
        {
            var list = new List<Armazem>();
            list.Add(new Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01", 5, 40));
            _repo.Setup(x => x.GetAllAsync()).ReturnsAsync(list);
            List<ArmazemDto> listDto = list.ConvertAll<ArmazemDto>(arm => 
                new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude, arm._CidadeNo.no, arm.Active, arm._Altitude.altitude)); 

            var result =  _service.GetAllAsync();
           Assert.Equal(listDto.ToString(), result.Result.ToString());
        }

         [Fact]
        public void GetByIdTest()
        {
            Armazem arm = new Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01",5, 40);

            _repo.Setup(x => x.GetByIdAsync(arm.Id)).ReturnsAsync(arm);
            var result =  _service.GetByIdAsync(arm.Id);
            ArmazemDto armDto = new ArmazemDto(arm.Id.AsGuid(), arm._Designacao.designacao ,arm._Endereco.endereco, arm._LojaId.id, arm._Municipio.municipe, arm._Latitude.latitude, arm._Longitude.longitude, arm._CidadeNo.no, arm.Active, arm._Altitude.altitude);
            
            Assert.Equal(result.Result.ToString(), armDto.ToString());
           
        }

        /* [Fact]
        public void AddAsyncTest()
        {

            cdto = new CreatingArmazemDto("Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48,5);

            arm = new DDDSample1.Domain.Armazens.Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01",5);
 
            adto = new ArmazemDto(arm.Id.AsGuid(),"Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48,5,true);
            
            _repo.Setup(x => x.AddAsync(arm)).ReturnsAsync(arm);
            
            Task<ArmazemDto> result = _service.AddAsync(cdto);

            Assert.Equal(result.Result.ToString(), adto.ToString());
        } */


        /*  [Fact]
        public void UpdateArmazemTest()
        {
            arm = new DDDSample1.Domain.Armazens.Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01");
            
             string designacao = "Armazem pequeno Paxeco";
            
             _repo.Setup(x => x.GetByIdAsync(arm.Id)).ReturnsAsync(arm);
            
            adto = new ArmazemDto(arm.Id.AsGuid(),designacao,"Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48);

        
             var result = _service.UpdateAsync(adto);
            
             Assert.Equal(result.Result.ToString(), adto.ToString());
            
        } */

         [Fact]
         public void GetByIdTestNull(){
            _repo.Setup(ent => ent.GetByIdAsync(It.IsAny<ArmazemId>())).ReturnsAsync(() => null);
            var result =  _service.GetByIdAsync(new ArmazemId(new Guid()));
            Assert.Null(result.Result);
        }
    }
}