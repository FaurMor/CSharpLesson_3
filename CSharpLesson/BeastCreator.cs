using System;

namespace CSharpLesson
{
    public class BeastCreator
    {
        private const int MaxHealth = 20;
        public Enemy CreateRandomBeast(Random random)
        {
            EmenyNames randomBeastName = (EmenyNames)random.Next(1, Enum.GetNames(typeof(EmenyNames)).Length);
            Elements randomElement = (Elements)random.Next(1, Enum.GetNames(typeof(Elements)).Length);
            float randomHealth = random.Next(1, MaxHealth + 1);
            Morals randomMoral = (Morals)random.Next(1, Enum.GetNames(typeof(Morals)).Length);
            Ethics randomEthic = (Ethics)random.Next(1, Enum.GetNames(typeof(Ethics)).Length);
            return new Enemy(randomBeastName.ToString(), randomElement, randomHealth, new Outlook(randomMoral, randomEthic));
        }
    }
}
