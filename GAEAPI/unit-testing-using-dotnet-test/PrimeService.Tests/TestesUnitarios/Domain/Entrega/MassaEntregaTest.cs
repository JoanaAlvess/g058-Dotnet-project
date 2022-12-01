using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas
{
    public class MassaEntregaTest
    {
        [Fact]
        public void SuccessfullyCreateMassaDeEntrega()
        {
            const double m = 25.0;
            MassaEntrega massaEnt = new MassaEntrega(m);
            
            Assert.Equal(m, massaEnt.massa);
        }

        [Fact]
        public void FailToCreateMassaDeEntregaComMassaNegativa()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new MassaEntrega(-12));
        }
    }
}