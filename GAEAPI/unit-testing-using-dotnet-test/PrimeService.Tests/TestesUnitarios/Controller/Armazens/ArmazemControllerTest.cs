using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using DDDSample1.Controllers;
using Xunit;
using Moq;

namespace PrimeService.Tests.TestesUnitarios.Controller
{
    public class ArmazemControllerTest
    {
        private readonly Mock<ArmazemService> _service;
        private readonly ArmazensController _controller;
        private CreatingArmazemDto cdto;
        

        public ArmazemControllerTest()
        {
            _service = new Mock<ArmazemService>();
            _controller = new ArmazensController(_service.Object);
            
             cdto = new CreatingArmazemDto("Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48,5,40);
          
            //Armazem arm = new DDDSample1.Domain.Armazens.Armazem(48,24,"Rua do Renan Bola Rebola,Porto,4000-100","Aramzem Grande Popular Do Porto XPO","Porto","Loja01");
           
            
        }

        /* [Fact]
        public async Task GetAllAsyncTest()
        {
       
            var result = await _controller.GetAll();

            _service.Verify(service => service.GetAllAsync(), Times.AtLeastOnce());
        }  */

        /*  [Fact]
        public async Task GetByIdTest()
        {
            Guid id = new Guid();
            _service.Setup(service => service.GetByIdAsync(It.IsAny<ArmazemId>()));

            var result = await _controller.GetGetById(id);

            _service.Verify(service => service.GetByIdAsync(It.IsAny<ArmazemId>()), Times.AtLeastOnce());
        } */ 

        /*   [Fact]
        public async Task PutAramzemTest()
        {
            Guid id = new Guid();
           
           
            List<Guid> missao = new List<Guid>();
            HashSet<Guid> relacao = new HashSet<Guid>();
            List<Guid> post = new List<Guid>();
            
            ArmazemDto adto = new ArmazemDto(Guid.NewGuid(),"Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48);

            _service.Setup(service => service.UpdateAsync(It.IsAny<ArmazemDto>()));

            var result = await _controller.Update(id, adto);

            _service.Verify(service => service.UpdateAsync(It.IsAny<ArmazemDto>()), Times.AtLeastOnce());
        } */

        /* [Fact]
        public async Task PostArmazemTest()
        {

             ArmazemDto adto = new ArmazemDto(Guid.NewGuid(),"Aramzem Grande Popular Do Porto XPO","Rua do Renan Bola Rebola,Porto,4000-100","Loja01","Porto",24,48);
            
            _service.Setup(service => service.AddAsync(It.IsAny<CreatingArmazemDto>())).Returns(Task.FromResult(adto));
           
            var result = await _controller.Create(cdto);
            _service.Verify(service => service.AddAsync(It.IsAny<CreatingArmazemDto>()), Times.AtLeastOnce());
            ActionResult<ArmazemDto> ArmazemDto = adto;
            Assert.IsType<ActionResult<ArmazemDto>>(result);
        }  */



    }
}