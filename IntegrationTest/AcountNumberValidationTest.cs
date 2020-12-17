using CarAndGo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validation;
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }
        [Fact]
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("86 004 8159"));
        }
        [Fact]
        public void IsNotValid_ValidAccountNumber_ReturnsFalse()
        {
            Assert.False(_validation.IsValid("17 004 8159"));
        }
    }
}
