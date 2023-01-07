using DDDSample1.Domain.Users;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Users
{
    public class NomeTest
    {
        [Fact]
        public void SuccessfullyCreateNome()
        {
            const string nome = "Miguel Huang Chen";
            Nome result = new Nome(nome);
            Assert.Equal(nome, result.nome);
        }   

        [Fact]
        public void SuccessfullyCreateNomeWithNumbers()
        {
            const string nome = "Miguel Huang Chen17";
            Nome result = new Nome(nome);
            Assert.Equal(nome, result.nome);
        }   

        [Fact]
        public void FailCreateNomeWithEmptyString()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Nome("    "));
        }

        [Fact]
        public void FailCreateNomeWithSpecialCharacters()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Nome("Miguel H@ang"));
        }
    }

}