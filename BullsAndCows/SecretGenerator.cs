using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        private Random random = new Random();
        public SecretGenerator()
        {
        }

        public SecretGenerator(Random random)
        {
            this.random = random;
        }

        public virtual string GenerateSecret()
        {
            List<int> secret = new List<int>();
            int randomDigit;
            for (int index = 0; index < 4;)
            {
                randomDigit = random.Next(10);
                if (!secret.Contains(randomDigit))
                {
                    secret.Add(randomDigit);
                    index++;
                }
            }

            return string.Join(" ", secret);
        }
    }
}