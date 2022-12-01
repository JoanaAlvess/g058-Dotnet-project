using DDDSample1.Domain.Shared;
using Xunit.Abstractions;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas {
    public class EntregaTest {

       private ArmazemId _armazemId;
       private string? _dataEnt;
       private double _massaEnt;     
       private int _tempoColocarEnt;
       private int _tempoRetirarEnt;

        public EntregaTest(ITestOutputHelper testOutputHelper){
            _armazemId = new ArmazemId(Guid.NewGuid());
            _dataEnt = "2023/10/28";
            _massaEnt = 8;
            _tempoColocarEnt = 5;
            _tempoRetirarEnt = 7;
        }

        private Entrega CreateEntrega() {
            return new Entrega(_armazemId, _dataEnt, _massaEnt, _tempoColocarEnt, _tempoRetirarEnt);
        }

        [Fact]
        public void SuccessfullyCreateEntrega() {
            var ent = CreateEntrega();
            Assert.True(ent != null);
        }

        [Fact]
        public void FailToCreateEntregaWithoutDataDeEntrega() {
            _dataEnt = null;
            Assert.Throws<BusinessRuleValidationException>(CreateEntrega);
        }
    }
}