namespace CSharpLesson
{
    public class Card : IAttacker, IConversator
    {
        public string Name { get; }
        public Element Element { get; }
        public Outlook Outlook { get; }
        public float Power { get; private set; }


        public Card(string name,
                    Element element,
                    float power,
                    Outlook outlook)
        {
            Name = name;
            Element = element;
            Power = power;
            Outlook = outlook;
        }

        public void Attack(IDefensive enemy)
        {
            enemy.TakeDamage(Power, Element);
        }

        public void TryConversate(IConversatable enemy)
        {
            enemy.Conversating(this);
        }
    }
}
