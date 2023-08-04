namespace CSharpLesson
{
    public interface IConversator : IConversate
    {
        void TryToConversate(IConversatable enemy);
    }
}
