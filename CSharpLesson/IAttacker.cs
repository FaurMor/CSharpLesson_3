using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public interface IAttacker : IFighter
    {
        float Power { get; }
        void Attack(IDefensive enemy);
    }
}
