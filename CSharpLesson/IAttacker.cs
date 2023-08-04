namespace CSharpLesson
{
    public interface IAttacker : IFighter
    {
        float Power { get; }
        void Attack(IDefensive enemy);
    }
}
