using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas
{
    public class TempoRetirarTest
    {
        [Fact]
        public void SuccessfullyCreateTempoDeRetirar()
        {
            const int t = 10;
            TempoRetirar time = new TempoRetirar(t);
            
            Assert.Equal(t, time._tempoRetirar);
        }

        [Fact]
        public void FailToCreateTempoDeRetirarComTempoNegativo()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new TempoRetirar(-5));
        }
    }
}