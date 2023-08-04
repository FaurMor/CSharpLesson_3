using System;

namespace CSharpLesson
{
    internal class Game
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.Write("Введите Ваше имя:");
            Hero hero = new Hero(Console.ReadLine());
            hero.GetCardPack();
            ConsolePrinter printer = new ConsolePrinter();
            MenuManager menuManager = new MenuManager();
            bool endGame = false;
            do
            {
                bool swapEnable = true;
                BeastCreator beastCreator = new BeastCreator();
                Enemy enemy = beastCreator.CreateRandomBeast(random);
                Console.WriteLine(printer.PrintEnemyIncoming(enemy.Name));
                Console.WriteLine(FighterInfo.GetBeastInfo(enemy));
                do
                {
                    Console.WriteLine(printer.PrintHeroActions());
                    int menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), menuManager.GetMainMenuCount());
                    switch (menuAnswer)
                    {
                        case MenuManager.MenuAttack:
                            {
                                Console.WriteLine(printer.PrintChooseCard());
                                Console.WriteLine(hero.HeroCasket.GetCardListToString());
                                menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.HeroCasket.GetCardCount());
                                if (menuAnswer == MenuManager.MenuWrongAnswer)
                                {
                                    Console.WriteLine(printer.PrintWrongAnswer(hero.HeroCasket.GetCardCount()));
                                }
                                else
                                {
                                    Card card = hero.HeroCasket.GetCard(menuAnswer);
                                    BattleManager battleManager = new BattleManager();
                                    if (battleManager.ToBattle(card, enemy))
                                    {
                                        Console.WriteLine(printer.PrintWinBattle(card.Name, enemy.Name));
                                        float score = 10;
                                        hero.AddScore(score);
                                        Console.WriteLine(printer.PrintAddScore(score));
                                    }
                                    else
                                    {
                                        Console.WriteLine(printer.PrintLoseBattle(card.Name, enemy.Name));
                                        endGame = true;
                                    }
                                }
                                break;
                            }
                        case MenuManager.MenuConversate:
                            {
                                Console.WriteLine(printer.PrintChooseCard());
                                Console.WriteLine(hero.HeroCasket.GetCardListToString());
                                menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.HeroCasket.GetCardCount());
                                if (menuAnswer == MenuManager.MenuWrongAnswer)
                                {
                                    Console.WriteLine(printer.PrintWrongAnswer(hero.HeroCasket.GetCardCount()));
                                }
                                else
                                {
                                    Card card = hero.HeroCasket.GetCard(menuAnswer);
                                    card.TryToConversate(enemy);
                                    if (enemy.IsConversatable)
                                    {
                                        Console.WriteLine(printer.PrintConversateSuccess(card.Name, enemy.Name));
                                        float score = 10;
                                        hero.AddScore(score);
                                        Console.WriteLine(printer.PrintAddScore(score));
                                    }
                                    else
                                    {
                                        Console.WriteLine(printer.PrintConversateFailed(enemy.Name));
                                        endGame = true;
                                    }
                                }
                                break;
                            }
                        case MenuManager.MenuCardInfo:
                            {
                                FighterInfo fighterInfo = new FighterInfo();
                                for (int cardIndex = 0; cardIndex < hero.HeroCasket.GetCardCount(); cardIndex++)
                                {
                                    Console.WriteLine(fighterInfo.GetCardInfo(hero.HeroCasket.GetCard(cardIndex)));
                                }
                                break;
                            }
                        case MenuManager.MenuCardSwap:
                            {
                                if (swapEnable)
                                {
                                    Console.WriteLine(printer.PrintChooseCard());
                                    Console.WriteLine(hero.HeroCasket.GetCardListToString());
                                    menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.HeroCasket.GetCardCount());
                                    if (menuAnswer == MenuManager.MenuWrongAnswer)
                                    {
                                        Console.WriteLine(printer.PrintWrongAnswer(hero.HeroCasket.GetCardCount()));
                                    }
                                    else
                                    {
                                        hero.HeroCasket.SwapCardToRandom(menuAnswer);
                                        Console.WriteLine(printer.PrintSwapingCard());
                                        swapEnable = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(printer.PrintSwapCardDenied());
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(printer.PrintWrongAnswer(hero.HeroCasket.GetCardCount()));
                                break;
                            }
                    }
                }
                while (!endGame && !enemy.IsDead && !enemy.IsConversatable);
            }
            while (!endGame);

            Console.WriteLine(printer.PrintGameResult(hero.Name, hero.Score));
            Console.ReadLine();
        }

        
    }
}
