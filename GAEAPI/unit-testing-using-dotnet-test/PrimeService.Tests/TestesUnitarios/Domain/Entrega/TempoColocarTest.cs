using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas
{
    public class TempoColocarTest
    {
        [Fact]
        public void SuccessfullyCreateTempoDeColocar()
        {
            const int t = 10;
            TempoColocar time = new TempoColocar(t);
            
            Assert.Equal(t, time._tempoColocar);
        }

        [Fact]
        public void FailToCreateTempoDeColocarComTempoNegativo()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new TempoColocar(-5));
        }
    }
}