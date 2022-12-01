using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class DesignacaoTest
    {
        [Fact]
        public void TestCreateDesigancaoCerto()
        {
            string designacao = "AramzemXpo";
            Designacao deg = new Designacao(designacao);
            
            Assert.Equal(designacao, deg.designacao);
        }
        
        [Fact]
        public void TestCreateDesignacaoErrado()
        {
            string designacao = "123456789012345678901234567890123456789012345678901";
            
            Assert.Throws<BusinessRuleValidationException>(() => new Designacao(designacao));
        }

        
    }
        
 }
