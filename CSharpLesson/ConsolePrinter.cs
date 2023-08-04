namespace CSharpLesson
{
    public class ConsolePrinter
    {
        public string PrintHeroActions()
            => "1.Атаковать\n\r2.Успокоить\n\r3.Посмотреть свои карты\n\r4.Поменять карту";

        public string PrintEnemyIncoming(string name)
            => $"К вам приближается {name}!";

        public string PrintWrongAnswer(int variantCount)
            => $"Введите число от 1 до {variantCount}";

        public string PrintChooseCard()
            => "Выберите карту:";

        public string PrintWinBattle(string card, string enemy)
            => $"Карта {card} одолела противника {enemy}!!";

        public string PrintLoseBattle(string card, string enemy)
            => $"Вы не справились с опасностей, {card}. Противник {enemy} оказался сильнее";

        public string PrintAddScore(float score)
            => $"Начислено {score} очков";

        public string PrintConversateSuccess(string card, string enemy)
            => $"{card} смог убедить противника {enemy}! Победа!!";

        public string PrintConversateFailed(string enemy)
            => $"Противник {enemy} не понял ваших слов... Битва проиграна.";

        public string PrintSwapingCard()
            => "Карта изменена";

        public string PrintSwapCardDenied()
            => "Вы уже поменяли карту в этом бою!";

        public string PrintGameResult(string heroName, float score)
            => $"{heroName} - Получено очков: {score}";
        }
}
