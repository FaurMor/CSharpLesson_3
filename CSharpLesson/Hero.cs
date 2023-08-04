namespace CSharpLesson
{
    public class Hero
    {
        public Casket HeroCasket { get; private set; }
        public string Name { get; }
        public float Score { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Score = 0;
            HeroCasket = new Casket();
        }

        public void GetCardPack()
        {
            HeroCasket.GetRandomCards();
        }

        public void SwapCard(int cardIndex)
            => HeroCasket.SwapCardToRandom(cardIndex);

        public void AddScore(float score)
        {
            Score += score;
        }
    }
}
