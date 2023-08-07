namespace CSharpLesson
{
    public interface IAttacker
    {
        float Power { get; }
        void Attack(IDefensive enemy);
    }
}
