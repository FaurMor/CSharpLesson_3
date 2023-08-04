namespace CSharpLesson
{
    public class FighterInfo
    {
        public string GetCardInfo(Card card)
        {
            string name = card.Name;
            float attack = card.Power;
            string element = card.Element.ToString();
            string moral = card.Outlook.Moral.ToString();
            string ethic = card.Outlook.Ethic.ToString();
            string result = $"====={name}=====\n\r";
            result += $"Атака: {attack}\n\rЭлемент: {element}\n\r" +
                      $"Мораль: {moral}\n\rЭтика: {ethic}\n\r=======================";
            return result;
        }

        public static string GetBeastInfo(Enemy beast)
        {
            string name = beast.Name;
            float health = beast.Health;
            string element = beast.Element.ToString();
            string moral = beast.Outlook.Moral.ToString();
            string ethic = beast.Outlook.Ethic.ToString();
            string result = $"======{name}======\n\r";
            result += $"Здоровье: {health}\n\rЭлемент: {element}\n\r" +
                      $"Мораль: {moral}\n\rЭтика: {ethic}\n\r=======================";
            return result;
        }

    }
}
