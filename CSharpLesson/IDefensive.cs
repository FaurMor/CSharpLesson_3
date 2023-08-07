namespace CSharpLesson
{
    public interface IDefensive
    {
        bool IsDead { get; }
        float Health { get; }
        void TakeDamage(float damage, Element enemyElement);
    }
}
