using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class Card : IAttacker, IConversator
    {
        public string Name { get; }
        public Elements Element { get; }
        public Outlook Outlook { get; }
        public float Power { get; private set; }


        public Card(string name,
                    Elements element,
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

        public void TryToConversate(IConversatable enemy)
        {
            enemy.Conversating(this);
        }

        public void Attack(IFighter enemy)
        {
            throw new NotImplementedException();
        }
    }
}
