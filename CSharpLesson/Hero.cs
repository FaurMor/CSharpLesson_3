namespace CSharpLesson
{
    public class Hero
    {
        public CardBox CardBox { get; private set; }
        public string Name { get; }
        public float Score { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Score = 0;
            CardBox = new CardBox();
        }

        public void GetCardPack()
        {
            CardBox.GenerateRandomCards();
        }

        public void SwapCard(int cardIndex)
            => CardBox.SwapCard(cardIndex);

        public void AddScore(float score)
        {
            Score += score;
        }
    }
}
