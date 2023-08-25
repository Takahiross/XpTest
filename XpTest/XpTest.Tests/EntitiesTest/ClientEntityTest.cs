using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XpTest.Domain.Entities;

namespace XpTest.Tests.EntitiesTest
{
    [TestClass]
    public class ClientEntityTest
    {
        private readonly Client _clientValid = new Client("Weslley Takahiro", "1234567890", "exemplo@email.com", new Address("", "", ""));
        private readonly Client _clientInvalid = new Client("Weslley Takahiro", "12345", "email@invalido", new Address("", "", ""));

        [TestMethod]
        [TestCategory("Domain")]
        public void PhoneValidTest()
        {
            bool valid = _clientValid.PhoneValidation(_clientValid.Phone);
            Assert.IsTrue(valid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void PhoneInvalidTest()
        {
            bool invalid = _clientInvalid.PhoneValidation(_clientInvalid.Phone);
            Assert.IsFalse(invalid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void EmailInvalidTest()
        {
            bool invalid = _clientInvalid.EmailValidation(_clientInvalid.Email);
            Assert.IsFalse(invalid);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void EmailValidTest()
        {
            bool valid = _clientValid.EmailValidation(_clientValid.Email);
            Assert.IsTrue(valid);
        }
    }
}
