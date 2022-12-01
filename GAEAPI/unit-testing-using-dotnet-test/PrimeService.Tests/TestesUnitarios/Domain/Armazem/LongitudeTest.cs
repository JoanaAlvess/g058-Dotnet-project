using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class LongitudeTest
    {
        [Fact]
        public void TestCreateLongitudeCerto()
        {
            double longitude = 180;
            Longitude lon = new Longitude(longitude);
            
            Assert.Equal(longitude,lon.longitude);
        }
        
        /* [Fact]
        public void TestCreateLongitudeErrado()
        {
            double longitude = 181;
            
            Assert.Throws<BusinessRuleValidationException>(() => new Longitude(longitude));
        } */

        
    }
        
 }
