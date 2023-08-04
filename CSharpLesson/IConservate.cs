namespace CSharpLesson
{
    public interface IConversatable : IConversate
    {
        bool IsConversatable { get; }
        void Conversating(IConversate enemy);
    }
}
