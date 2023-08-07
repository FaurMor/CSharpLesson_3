namespace CSharpLesson
{
    public class Outlook
    {
        public Morals Moral { get; }
        public Ethic Ethic { get; }
        public float OutlookEquivalent => (float)Moral * (float)Ethic;

        public Outlook(Morals moral, Ethic ethics)
        {
            Moral = moral;
            Ethic = ethics;
        }
    }
}
