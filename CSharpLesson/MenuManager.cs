namespace CSharpLesson
{
    public class MenuManager
    {
        private const int MainMenuCount = 4;
        public const int MenuAttack = 0;
        public const int MenuConversate = 1;
        public const int MenuCardInfo = 2;
        public const int MenuCardSwap = 3;
        public const int MenuWrongAnswer = -1;

        public int ChooseHeroAction(string answer, int variantCount)
            => CheckNumber(variantCount, ReadNumber(answer));

        public int GetMainMenuCount() => MainMenuCount;

        private int ReadNumber(string number)
        {
            if (int.TryParse(number, out int result))
            {
                return result - 1;
            }
            else
            {
                return -1;
            }
        }

        private int CheckNumber(int variantCount, int choose)
        {
            if (choose >= 0 && choose < variantCount)
            {
                return choose;
            }
            else
            {
                return -1;
            }
        }
    }
}
