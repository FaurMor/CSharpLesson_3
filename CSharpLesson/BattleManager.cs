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
