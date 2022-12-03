using DDDSample1.Domain.Shared;
using Xunit.Abstractions;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;
using System.Collections.Generic;
using DDDSample1.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace PrimeService.Tests.TestesUnitarios.Controller.Entregas {
    
    public class EntregasControllerTest {
        private readonly Mock<IUnitOfWork> _unit;
        private readonly Mock<IEntregaRepository> _repo;
        private readonly EntregaService _service;
        private readonly EntregasController _controller;
        private CreatingEntregaDto cdto;
        private Entrega _entrega;
        private EntregaDto entregaDto;

        public EntregasControllerTest(){
            _unit = new Mock<IUnitOfWork>();
            _repo = new Mock<IEntregaRepository>();
            _service = new EntregaService(_unit.Object, _repo.Object);
            _controller = new EntregasController(_service);
            
            ArmazemId entId = new ArmazemId(new Guid());
            _entrega = new Entrega(entId, "2022/12/10", 12, 6, 3);
            string entIdString = entId.AsString();
            cdto = new CreatingEntregaDto(entIdString, "2022/12/10", 12, 6, 3);
            entregaDto = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, "2022/12/10", 12, 6, 3);
        }

      [Fact]
        public async void ReturnsExpectedObjectWhenEntregaIsCreatedSuccessfully()
        {
            _repo.Setup(x => x.AddAsync(It.IsAny<Entrega>())).Returns(Task.FromResult<Entrega>(_entrega));
            var result = await _controller.Create(cdto);

            var actionResult = Assert.IsType<ActionResult<EntregaDto>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<EntregaDto>(createdAtActionResult.Value);
        }

        [Fact]
        public async void ReturnsCreatedAtActionWhenEntregarIsCreatedSuccessfully(){
            _repo.Setup(x => x.AddAsync(It.IsAny<Entrega>())).Returns(Task.FromResult<Entrega>(_entrega));
            var result = await _controller.Create(cdto);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        /* [Fact]
        public async void ReturnsBadRequestWhenEntregaAlreadyExists()
        {
            _repo.Setup(x => x.AddAsync(It.IsAny<Entrega>())).Returns(Task.FromResult<Entrega>(_entrega));
            await _controller.Create(cdto);
            _repo.Setup(x => x.AddAsync(It.IsAny<Entrega>())).Throws(new DbUpdateException());
            var result = await _controller.Create(cdto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        } */

        [Fact]
        public async void ReturnsOkEntregaFound()
        {
            _repo.Setup(x => x.GetByIdAsync(_entrega.Id)).Returns(Task.FromResult(_entrega));
            var result = await _controller.Update(entregaDto.Id, entregaDto);
            Assert.IsType<OkObjectResult>(result.Result);
        }

       [Fact]
        public async void ReturnsOkFoundSpecificEntrega()
        {
          var dtoGuid = _entrega.Id.AsGuid();
          var dto = new EntregaDto(dtoGuid, entregaDto.Armazem_Id, "2022/12/10", 29, 4, 4);
          
          _repo.Setup(x => x.GetByIdAsync(It.IsAny<EntregaId>())).Returns(Task.FromResult(_entrega));
          var result = await _controller.Update(dtoGuid, entregaDto);

          var actionResult = Assert.IsType<ActionResult<EntregaDto>>(result);
          //var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
          //var returnValue = Assert.IsType<EntregaDto>(createdAtActionResult.Value);
          //Assert.Equal(dto.Armazem_Id, returnValue.Armazem_Id);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                );
        }

        [Fact]
        public async void ReturnsBadRequestUponCatchingBusinessRuleValidationException()
        {
            _repo.Setup(x => x.GetByIdAsync(It.IsAny<EntregaId>()))
                .Throws(new BusinessRuleValidationException("test"));
            var result = await _controller.Update(entregaDto.Id, entregaDto);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void ReturnsNotFoundWithNonExistingEntrega()
        {
            _repo.Setup(x => x.GetByIdAsync(It.IsAny<EntregaId>()))
                .Returns(Task.FromResult<Entrega>(null));
            var result = await _controller.Update(entregaDto.Id, entregaDto);
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}    