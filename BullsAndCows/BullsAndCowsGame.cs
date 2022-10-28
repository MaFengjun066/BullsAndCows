using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            int countAllCorrectDigitalIgnorePosition = CountAllCorrectDigitalIgnorePosition(guess);
            int countBulls = CountBulls(guess);

            return $"{countBulls}A{countAllCorrectDigitalIgnorePosition - countBulls}B";
        }

        private int CountAllCorrectDigitalIgnorePosition(string guess)
        {
            var guessDigits = guess.Split(' ');
            int countCow = 0;
            for (var index = 0; index < guessDigits.Length; index++)
            {
                if (secret.Contains(guessDigits[index]))
                {
                    countCow++;
                }
            }

            return countCow;
        }

        private int CountBulls(string guess)
        {
            var guessDigits = guess.Split(' ');
            var secretDigits = secret.Split(' ');
            int countBulls = 0;
            for (var index = 0; index < secretDigits.Length; index++)
            {
                if (guessDigits[index] == secretDigits[index])
                {
                    countBulls++;
                }
            }

            return countBulls;
        }
    }
}