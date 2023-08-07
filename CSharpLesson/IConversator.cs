namespace CSharpLesson
{
    public interface IConversator
    {
        Outlook Outlook { get; }
        void TryConversate(IConversatable enemy);
    }
}
