using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_return_4A0B_when_given_guess_digits_are_same_with_secret()
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 3 4");
            //then
            Assert.Equal("4A0B", guessResult);
        }

        [Fact]
        public void Should_return_3A0B_when_given_guess_digits_have_2_correct_digitals_and_2_wrong_digital()
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess("1 2 6 5");
            //then
            Assert.Equal("2A0B", guessResult);
        }
    }
}
