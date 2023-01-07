using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class LojaIdTest
    {
        [Fact]
        public void TestCreateLojaIdCerto()
        {
            string lojaId = "Loja12";
            LojaId li = new LojaId(lojaId);

            Assert.Equal(lojaId, li.lojaId);
        }
        
        [Fact]
        public void TestCreateLojaIdErrado()
        {
            string id = "ola";
            
            Assert.Throws<BusinessRuleValidationException>(() => new LojaId(id));
        }

        
    }
        
 }
