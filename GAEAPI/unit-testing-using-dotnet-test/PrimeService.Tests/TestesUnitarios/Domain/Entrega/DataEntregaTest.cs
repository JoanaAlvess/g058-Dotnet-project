using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Entregas
{
    public class DataEntregaTest
    {
        [Fact]
        public void SuccessfullyCreateDataDeEntrega()
        {
            const string d = "2001/12/11";
            DataEntrega date = new DataEntrega(d);
            
            Assert.Equal(d, date.data);
        }

        [Fact]
        public void FailToCreateDataDeEntregaComDataVazia()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new DataEntrega(""));
        }

        [Fact]
        public void FailToCreateDataDeEntregaComDataNull()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new DataEntrega(null));
        }

        [Fact]
        public void FailToCreateDataDeEntregaComFormatoInválido()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new DataEntrega("10/2022/12"));
        }
    }
}