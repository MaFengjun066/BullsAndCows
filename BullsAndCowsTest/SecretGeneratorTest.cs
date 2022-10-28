using BullsAndCows;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGeneratorTest
    {
        [Fact]
        public void Should_return_secret_4_characters()
        {
            //given
            SecretGenerator secretGenerator = new SecretGenerator();
            //when
            string secret = secretGenerator.GenerateSecret();
            //then
            Assert.Equal(4, secret.Split(' ').Length);
        }

        [Fact]
        public void Should_return_secret_with_4_random_digits_is_different_when_generate()
        {
            //given
            var mockRandom = new Mock<Random>();
            mockRandom.SetupSequence(random => random.Next(It.IsAny<int>())).Returns(1).Returns(2).Returns(2).Returns(1).Returns(7).Returns(9).Returns(7);
            var scecretGenerator = new SecretGenerator(mockRandom.Object);
            //when
            var secret = scecretGenerator.GenerateSecret();
            //then
            Assert.Equal("1 2 7 9", secret);
        }
    }
}
