namespace CSharpLesson
{
    public class Enemy : IDefensive, IConversatable
    {
        public string Name { get; }
        public Elements Element { get; }
        public Outlook Outlook { get; }
        public float Health { get; private set; }
        public bool IsDead { get; private set; }
        public bool IsConversatable { get; private set; }

        public Enemy(string name,
                        Elements element,
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

        public void TakeDamage(float damage, Elements enemyElement)
        {
            ElementCoefficient coefficient = new ElementCoefficient();
            float totalDamage = damage * coefficient.GetElementCoefficient(enemyElement, Element);
            if (totalDamage >= Health)
            {
                IsDead = true;
            }
        }

        public void Conversating(IConversate enemy)
        {
            ConversateManager conversateManager = new ConversateManager();
            if (conversateManager.GetConversateResult(enemy, this))
            {
                IsConversatable = true;
            }
        }
    }
}
