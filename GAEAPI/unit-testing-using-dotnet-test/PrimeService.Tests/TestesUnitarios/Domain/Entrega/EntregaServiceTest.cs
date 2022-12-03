using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;
using Moq;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas {
    public class EntregaServiceTest {
        
        private readonly EntregaService _service;
        private readonly Mock<IUnitOfWork> _unit;
        private readonly Mock<IEntregaRepository> _repo;
        
        public EntregaServiceTest(){
            _unit = new Mock<IUnitOfWork>();
            _repo = new Mock<IEntregaRepository>();
            _service = new EntregaService(_unit.Object, _repo.Object);
           // _unit.Setup(x => x.CommitAsync()).Returns(Task.FromResult(1));
        }

        [Fact]
        public void GetAllAsyncTest(){
            var list = new List<Entrega>();
            list.Add(new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3));
            _repo.Setup(ent => ent.GetAllAsync()).ReturnsAsync(list);
            var result = _service.GetAllAsync();
            
            List<EntregaDto> resultDTO = list.ConvertAll<EntregaDto>(ent => 
                new EntregaDto(ent.Id.AsGuid(), ent._ArmazemId, ent._DataEntrega.data, ent._MassaEntrega.massa, ent._TempoColocar._tempoColocar, ent._TempoRetirar._tempoRetirar)); 
               
            Assert.Equal(resultDTO.ToString(), result.Result.ToString());
        }

        [Fact]
        public void GetByIdAsyncTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3);

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            var result = _service.GetByIdAsync(_entrega.Id);
            EntregaDto entregaDto = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, _entrega._DataEntrega.data, _entrega._MassaEntrega.massa, _entrega._TempoColocar._tempoColocar, _entrega._TempoRetirar._tempoRetirar);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        }

        [Fact]
        public void GetByIdTestNull(){
            _repo.Setup(ent => ent.GetByIdAsync(It.IsAny<EntregaId>())).ReturnsAsync(() => null);
            var result =  _service.GetByIdAsync(new EntregaId(new Guid()));
            Assert.Null(result.Result);
        }

        [Fact]
        public void AddAsyncTest(){
            ArmazemId entId = new ArmazemId(new Guid());
            string entIdString = entId.AsString();

            Entrega _entrega = new Entrega(entId, "2001/12/11", 12, 6, 3);
            CreatingEntregaDto cdto = new CreatingEntregaDto(entIdString, "2001/12/11", 12, 6, 3);
            EntregaDto entregaDto = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, "2001/12/11", 12, 6, 3);
            
            _repo.Setup(ent => ent.AddAsync(_entrega)).ReturnsAsync(_entrega);
            Task<EntregaDto> result = _service.AddAsync(cdto);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        } 

        [Fact]
        public void UpdateDataDeEntregaTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3);
            string dataEntrega = "2001/12/10";

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            EntregaDto entregaDto  = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, dataEntrega, 12, 6, 3);

            var result = _service.UpdateAsync(entregaDto);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        }

        [Fact]
        public void UpdateMassaDeEntregaTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3);
            double massaEntrega = 10.5;

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            EntregaDto entregaDto  = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, "2001/12/11", massaEntrega, 6, 3);

            var result = _service.UpdateAsync(entregaDto);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        }

        [Fact]
        public void UpdateTempoDeColocarEntregaTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3);
            int tempoColocarEntrega = 10;

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            EntregaDto entregaDto  = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, "2001/12/11", 12, tempoColocarEntrega, 3);

            var result = _service.UpdateAsync(entregaDto);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        }

        [Fact]
        public void UpdateTempoDeRetirarEntregaTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "2001/12/11", 12, 6, 3);
            int tempoRetirarEntrega = 10;

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            EntregaDto entregaDto  = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, "2001/12/11", 12, 6, tempoRetirarEntrega);

            var result = _service.UpdateAsync(entregaDto);

            Assert.Equal(result.Result.ToString(), entregaDto.ToString());
        }

        /* [Fact]
        public void GetByArmazemIdTest(){
            Entrega _entrega = new Entrega(new ArmazemId(new Guid()), "17/11/2001", 12, 6, 3);
            EntregaDto entregaDto  = new EntregaDto(_entrega.Id.AsGuid(), _entrega._ArmazemId, _entrega._DataEntrega.data, _entrega._MassaEntrega.massa, _entrega._TempoColocar._tempoColocar, _entrega._TempoRetirar._tempoRetirar);

            List<EntregaDto> listDto = new List<EntregaDto>();
            listDto.Add(entregaDto);

            _repo.Setup(ent => ent.GetByIdAsync(_entrega.Id)).ReturnsAsync(_entrega);
            
            var result = _service.GetByArmazemId(_entrega._ArmazemId);

            Assert.Equal(result.Result.ToString(), listDto.ToString());
        } */
    }
}