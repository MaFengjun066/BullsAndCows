using BullsAndCows;
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
    }
}
