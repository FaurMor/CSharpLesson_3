using System;
using System.Collections.Generic;

namespace CSharpLesson
{
    public class CardBox
    {
        private const int MaxPower = 20;
        private const int MaxCards = 5;
        private Random _random;
        private List<Card> _cards;

        public int CardsCount => _cards.Count;

        public CardBox()
        {
            _cards = new List<Card>();
            _random = new Random();
        }

        public void GenerateRandomCards()
        {
            if (_cards == null)
                    _cards = new List<Card>();
            else    _cards.Clear();

            for (int card = 0; card < MaxCards; card++)
            {
                _cards.Add(CreateRandomCard());
            }
        }

        public string GetCardsString()
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

        public void SwapCard(int cardIndex)
            => _cards[cardIndex] = CreateRandomCard();

        private Card CreateRandomCard()
        {
            CardNames randomCardName = (CardNames)_random.Next(1, Enum.GetNames(typeof(CardNames)).Length);
            Element randomElement = (Element)_random.Next(1, Enum.GetNames(typeof(Element)).Length);
            float randomPower = _random.Next(1, MaxPower + 1);
            Morals randomMoral = (Morals)_random.Next(1, Enum.GetNames(typeof(Morals)).Length);
            Ethic randomEthic = (Ethic)_random.Next(1, Enum.GetNames(typeof(Ethic)).Length);

            return new Card(randomCardName.ToString(), randomElement, randomPower, new Outlook(randomMoral, randomEthic));
        }
    }
}
