using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Shared;
using Xunit;

namespace PrimeService.Tests.TestesUnitarios.Domain.Armazens
{
    public class EnderecoTest
    {
        [Fact]
        public void TestCreateEnderecoCerto()
        {
            string endereco = "Rua do Paxeco,Porto,4000-560";
            Endereco end = new Endereco(endereco);
            
            Assert.Equal(endereco, end.endereco);
        }
        
        [Fact]
        public void TestCreateEnderecoErrado()
        {
            string endereco = "Rua normal";
            
            Assert.Throws<BusinessRuleValidationException>(() => new Endereco(endereco));
        }

        
    }
        
 }
