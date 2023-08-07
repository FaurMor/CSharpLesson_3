namespace CSharpLesson
{
    public class Battle
    {
        public bool StartBattle(IAttacker attacker, IDefensive defensive)
        {
            attacker.Attack(defensive);
            return defensive.IsDead;
        }
    }
}
