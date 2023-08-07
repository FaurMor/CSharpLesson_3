namespace CSharpLesson
{
    public class Enemy : IDefensive, IConversatable
    {
        public string Name { get; }
        public Element Element { get; }
        public Outlook Outlook { get; }
        public float Health { get; private set; }
        public bool IsDead { get; private set; }
        public bool IsConversatable { get; private set; }

        public Enemy(string name,
                        Element element,
                        float health,
                        Outlook outlook)
        {
            Name = name;
            Element = element;
            Health = health;
            Outlook = outlook;
            IsDead = false;
            IsConversatable = false;
        }

        public void TakeDamage(float damage, Element enemyElement)
        {
            ElementCoefficient coefficient = new ElementCoefficient();
            float totalDamage = damage * coefficient.GetElementCoefficient(enemyElement, Element);
            IsDead = totalDamage >= Health;
        }

        public void Conversating(IConversator conversator)
        {
            Conversate conversateManager = new Conversate();
            IsConversatable = conversateManager.GetConversateResult(conversator, this);
        }
    }
}
