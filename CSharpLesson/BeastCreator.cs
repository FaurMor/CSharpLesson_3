using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class BeastCreator
    {
        private const int MaxHealth = 20;
        public Beast CreateRandomBeast()
        {
            Random random = new Random();
            Thread.Sleep(50);
            BeastNames randomBeastName = (BeastNames)random.Next(1, Enum.GetNames(typeof(BeastNames)).Length);
            Elements randomElement = (Elements)random.Next(1, Enum.GetNames(typeof(Elements)).Length);
            float randomHealth = random.Next(1, MaxHealth + 1);
            Morals randomMoral = (Morals)random.Next(1, Enum.GetNames(typeof(Morals)).Length);
            Ethics randomEthic = (Ethics)random.Next(1, Enum.GetNames(typeof(Ethics)).Length);
            return new Beast(randomBeastName.ToString(), randomElement, randomHealth, new Outlook(randomMoral, randomEthic));
        }
    }
}
