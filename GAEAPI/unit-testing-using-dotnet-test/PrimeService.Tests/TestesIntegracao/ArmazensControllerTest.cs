using DDDSample1.Domain.Armazens;

using DDDSample1.Controllers;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DDDSample1.Domain.Shared;

namespace Tests.testesIntegracao
{
   /* public class ArmazemControllerTest
    {

         private readonly Mock<IArmazemRepository> _repo;

         private readonly Mock<IUnitOfWork> _unit;
        private readonly ArmazensController _controller;
        private readonly ArmazemService _service;
        private CreatingArmazemDto cdto;
        

        public ArmazemControllerTest()
        {

            _repo = new Mock<IArmazemRepository>();
            _unit = new Mock<IUnitOfWork>();
            _service = new ArmazemService(_unit.Object,_repo.Object);
            _controller = new ArmazensController(_service);
            
            
        }
        [Fact]
        public async Task GetAllAsyncTest()
        {
           
            _repo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(new List<Armazem>()));

            var result = await _controller.GetAll();

            _repo.Verify(service => service.GetAllAsync(), Times.AtLeastOnce());
        }

        [Fact]
        public async Task GetByIdTest()
        {
            Guid id = new Guid();

            _repo.Setup(repository => repository.GetByIdAsync(It.IsAny<ArmazemId>()));

            var mockUnit = new Mock<IUnitOfWork>();

            var result = await _controller.GetGetById(id);

            _repo.Verify(service => service.GetByIdAsync(It.IsAny<ArmazemId>()), Times.AtLeastOnce());
        }

        [Fact]
        public async void PostArmazemTest()

        {
            CreatingArmazemDto cdto = new CreatingArmazemDto("Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48);

            Armazem arm = new DDDSample1.Domain.Armazens.Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01");

            ArmazemDto adto = new ArmazemDto(arm.Id.AsGuid(),"Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48);
            _repo.Setup(x => x.AddAsync(It.IsAny<Armazem>())).Returns(Task.FromResult<Armazem>(arm));
          
        }
    
    }*/
}
