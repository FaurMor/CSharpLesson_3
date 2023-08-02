using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class Beast : IDefensive, IConversatable
    {
        public string Name { get; }
        public Elements Element { get; }
        public Outlook Outlook { get; }
        public float Health { get; private set; }
        public bool IsDead { get; private set; }
        public bool IsConversatable { get; private set; }

        public Beast(string name,
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
            float totalDamage = damage * ElementCoefficient.GetElementCoefficient(enemyElement, Element);
            if (totalDamage >= Health)
            {
                IsDead = true;
            }
        }

        public void Conversating(IConversate enemy)
        {
            if (Conversation.GetConservateResult(enemy, this))
            {
                IsConversatable = true;
            }
        }
    }
}
