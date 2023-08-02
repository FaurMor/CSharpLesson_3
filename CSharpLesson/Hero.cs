using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class Hero
    {
        public Casket Casket { get; private set; }
        public string Name { get; }
        public float Score { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Score = 0;
        }

        public void GetCardPack()
        {
            this.Casket = new Casket();
            this.Casket.GetRandomCards();
        }

        public void SwapCard(int cardIndex)
            => this.Casket.SwapCardToRandom(cardIndex);

        public void AddScore(float score)
        {
            Score += score;
        }
    }
}
