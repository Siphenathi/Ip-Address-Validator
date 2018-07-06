using NUnit.Framework;
using IpAddressValidation.Logic;

namespace IpAddressValidation.Test
{
    [TestFixture]
    public class IpAddressValidatorTests
    {


        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("1.1.1.")]
        public void ValidateIpv4Address_GivenInvalidIpAddress_ShouldReturnFalse(string ipAddress)
        {
            //Arrange
            var expected = false;

            var sut = CreateIpAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("0.0.0.0")]
        [TestCase("255.255.255.255")]
        [TestCase("10.0.1")]
        [TestCase("1.1.1.0")]
        public void ValidateIpv4Address_GivenValidIpAddressThatCannotBeUsedAsHostAddress_ShouldReturnFalse(string ipAddress)
        {
            //Arrange
            var expected = false;

            var sut = CreateIpAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1.1.1.1")]
        [TestCase("192.168.1.1")]
        [TestCase("10.0.0.1")]
        [TestCase("127.0.0.1")]
        public void ValidateIpv4Address_GivenValidIpAddress_ShouldReturnTrue(string ipAddress)
        {
            //Arrange
            var expected = true;

            var sut = CreateIpAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(ipAddress);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public IpAddressValidator CreateIpAddressValidator()
        {
            return new IpAddressValidator();
        }
    }
}
