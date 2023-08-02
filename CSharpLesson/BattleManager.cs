using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    public class BattleManager
    {
        public bool ToBattle(IAttacker attacker, IDefensive defensive)
        {
            attacker.Attack(defensive);
            return defensive.IsDead;
        }
    }
}
