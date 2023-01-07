using DDDSample1.Domain.Users;
using DDDSample1.Domain.Shared;

namespace PrimeService.Tests.TestesUnitarios.Domain.Users
{
    public class EmailTest
    {
        [Fact]
        public void SuccessfullyCreateEmail()
        {
            const string email = "tate123@gmail.com";
            Email result = new Email(email);
            Assert.Equal(email, result.email);
        }

        [Fact]
        public void SuccessfullyCreateEmailWithWhiteSpaceAtTheEnd()
        {
            const string email = "1234@gmail.com  ", expected="1234@gmail.com";
            Email result = new Email(email);
            Assert.Equal(expected,result.email);
        }
        
        [Fact]
        public void SuccessfullyCreateEmailWithWhiteSpaceAtTheBeginning()
        {
            const string email = "    1234@gmail.com", expected="1234@gmail.com";
            Email result = new Email(email);
            Assert.Equal(expected, result.email);
        }
        
        [Fact]
        public void FailCreateEmailWithEmptyString()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Email("    "));
        }
        
        [Fact]
        public void FailCreateEmailWithNullString()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Email(null));
        }
        
        [Fact]
        public void FailCreateEmailWithEmailWithoutAtSymbol()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Email("1234gmail"));
        }
    }
}