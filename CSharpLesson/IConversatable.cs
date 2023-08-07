namespace CSharpLesson
{
    public interface IConversatable
    {
        Outlook Outlook { get; }
        bool IsConversatable { get; }
        void Conversating(IConversator conversator);
    }
}
