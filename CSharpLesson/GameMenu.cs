namespace CSharpLesson
{
    public class GameMenu
    {
        public const int MainMenuCount = 4;
        public const int MenuAttack = 0;
        public const int MenuConversate = 1;
        public const int MenuCardInfo = 2;
        public const int MenuCardSwap = 3;
        public const int MenuWrongAnswer = -1;

        public int ChooseHeroAction(string answer, int variantCount)
            => CheckNumber(variantCount, ReadNumber(answer));

        private int ReadNumber(string number) 
            => int.TryParse(number, out int result) ? result - 1 : 0;

        private int CheckNumber(int variantCount, int choose)
            => choose >= 0 && choose < variantCount ? choose : -1;
    }
}
