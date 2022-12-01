using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class MunicipioTest
    {
        [Fact]
        public void TestCreateMunicipioCerto()
        {
            string municipio = "Porto";
            Municipio mun = new Municipio(municipio);
            
            Assert.Equal(municipio, mun.municipe);
        }
        
        [Fact]
        public void TestCreateMnicipioErrado()
        {
            string municipio = "";
            
            Assert.Throws<BusinessRuleValidationException>(() => new Municipio(municipio));
        }

        
    }
        
 }
