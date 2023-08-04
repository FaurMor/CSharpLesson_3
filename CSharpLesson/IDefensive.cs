namespace CSharpLesson
{
    public interface IDefensive : IFighter
    {
        bool IsDead { get; }
        float Health { get; }
        void TakeDamage(float damage, Elements enemyElement);
    }
}
