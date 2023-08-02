using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class Casket
    {
        private const int MaxPower = 20;
        private const int MaxCards = 5;
        private Random _random;

        private List<Card> _cards;

        public void GetRandomCards()
        {
            if (_cards == null)
            {
                _cards = new List<Card>();
            }
            else _cards.Clear();
            _random = new Random();
            for (int card = 0; card < MaxCards; card++)
            {
                _cards.Add(CreateRandomCard());
            }
        }

        public string GetCardListToString()
        {
            string result = string.Empty;
            for (int cardIndex = 0; cardIndex < _cards.Count; cardIndex++)
            {
                result += $"{cardIndex + 1}. " + _cards[cardIndex].Name + "\n\r";
            }
            return result;
        }
        public Card GetCard(int card)
            => _cards[card];

        public int GetCardCount()
            => _cards.Count;

        public void SwapCardToRandom(int cardIndex)
            => _cards[cardIndex] = CreateRandomCard();

        private Card CreateRandomCard()
        {
            CardNames randomCardName = (CardNames)_random.Next(1, Enum.GetNames(typeof(CardNames)).Length);
            Elements randomElement = (Elements)_random.Next(1, Enum.GetNames(typeof(Elements)).Length);
            float randomPower = _random.Next(1, MaxPower + 1);
            Morals randomMoral = (Morals)_random.Next(1, Enum.GetNames(typeof(Morals)).Length);
            Ethics randomEthic = (Ethics)_random.Next(1, Enum.GetNames(typeof(Ethics)).Length);

            return new Card(randomCardName.ToString(), randomElement, randomPower, new Outlook(randomMoral, randomEthic));
        }
    }
}
