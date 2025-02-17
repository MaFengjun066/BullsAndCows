using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        private const string Secret = "1 2 3 4";

        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

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

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        [InlineData("1 2 3 4", "5 6 3 4")]
        public void Should_return_2A0B_when_given_guess_digits_have_2_correct_digitals_and_2_wrong_digital(string secret, string guess)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guess);
            //then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 5 2 6")]
        [InlineData("1 2 3 4", "2 5 3 6")]
        [InlineData("1 2 3 4", "5 3 6 4")]
        public void Should_return_1A1B_when_given_guess_digits_have_1_correct_digitals_and_1_correct_digital_but_wrong_position(string secret, string guess)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            //when
            var guessResult = game.Guess(guess);
            //then
            Assert.Equal("1A1B", guessResult);
        }
    }
}
