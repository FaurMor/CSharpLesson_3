using System;

namespace CSharpLesson
{
    public class BeastCreator
    {
        private const int MaxHealth = 20;
        public Enemy CreateRandomBeast(Random random)
        {
            EnemyNames randomBeastName = (EnemyNames)random.Next(1, Enum.GetNames(typeof(EnemyNames)).Length);
            Element randomElement = (Element)random.Next(1, Enum.GetNames(typeof(Element)).Length);
            float randomHealth = random.Next(1, MaxHealth + 1);
            Morals randomMoral = (Morals)random.Next(1, Enum.GetNames(typeof(Morals)).Length);
            Ethic randomEthic = (Ethic)random.Next(1, Enum.GetNames(typeof(Ethic)).Length);
            return new Enemy(randomBeastName.ToString(), randomElement, randomHealth, new Outlook(randomMoral, randomEthic));
        }
    }
}
