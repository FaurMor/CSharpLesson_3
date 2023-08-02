using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public interface IDefensive : IFighter
    {
        bool IsDead { get; }
        float Health { get; }
        void TakeDamage(float damage, Elements enemyElement);
    }
}
