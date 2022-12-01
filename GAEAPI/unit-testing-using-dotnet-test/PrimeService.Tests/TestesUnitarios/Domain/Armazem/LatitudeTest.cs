using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class LatitudeTest
    {
        [Fact]
        public void TestCreateLatitudeCerto()
        {
            double latitude = 10;
            Latitude lat = new Latitude(latitude);
            
            Assert.Equal(latitude, lat.latitude);
        }
        
        /* [Fact]
        public void TestCreateLatitudeErrado()
        {
            double latitude = 91;
            
            Assert.Throws<BusinessRuleValidationException>(() => new Latitude(latitude));
        } */

        
    }
        
 }
