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
            hero.CardBox.GenerateRandomCards();
            ConsolePrinter printer = new ConsolePrinter();
            GameMenu menuManager = new GameMenu();
            FighterInfo fighterInfo = new FighterInfo();
            bool endGame = false;
            do
            {
                bool swapEnable = true;
                BeastCreator beastCreator = new BeastCreator();
                Enemy enemy = beastCreator.CreateRandomBeast(random);
                Console.WriteLine(printer.PrintEnemyIncoming(enemy.Name));
                Console.WriteLine(fighterInfo.GetBeastInfo(enemy));
                do
                {
                    Console.WriteLine(printer.PrintHeroActions());
                    int menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), GameMenu.MainMenuCount);
                    switch (menuAnswer)
                    {
                        case GameMenu.MenuAttack:
                            {
                                Console.WriteLine(printer.PrintChooseCard());
                                Console.WriteLine(hero.CardBox.GetCardsString());
                                menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.CardBox.CardsCount);
                                if (menuAnswer == GameMenu.MenuWrongAnswer)
                                {
                                    Console.WriteLine(printer.PrintWrongAnswer(hero.CardBox.CardsCount));
                                }
                                else
                                {
                                    Card card = hero.CardBox.GetCard(menuAnswer);
                                    Battle battleManager = new Battle();
                                    if (battleManager.StartBattle(card, enemy))
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
                        case GameMenu.MenuConversate:
                            {
                                Console.WriteLine(printer.PrintChooseCard());
                                Console.WriteLine(hero.CardBox.GetCardsString());
                                menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.CardBox.CardsCount);
                                if (menuAnswer == GameMenu.MenuWrongAnswer)
                                {
                                    Console.WriteLine(printer.PrintWrongAnswer(hero.CardBox.CardsCount));
                                }
                                else
                                {
                                    Card card = hero.CardBox.GetCard(menuAnswer);
                                    card.TryConversate(enemy);
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
                        case GameMenu.MenuCardInfo:
                            {
                                for (int cardIndex = 0; cardIndex < hero.CardBox.CardsCount; cardIndex++)
                                {
                                    Console.WriteLine(fighterInfo.GetCardInfo(hero.CardBox.GetCard(cardIndex)));
                                }
                                break;
                            }
                        case GameMenu.MenuCardSwap:
                            {
                                if (swapEnable)
                                {
                                    Console.WriteLine(printer.PrintChooseCard());
                                    Console.WriteLine(hero.CardBox.GetCardsString());
                                    menuAnswer = menuManager.ChooseHeroAction(Console.ReadLine(), hero.CardBox.CardsCount);
                                    if (menuAnswer == GameMenu.MenuWrongAnswer)
                                    {
                                        Console.WriteLine(printer.PrintWrongAnswer(hero.CardBox.CardsCount));
                                    }
                                    else
                                    {
                                        hero.CardBox.SwapCard(menuAnswer);
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
                                Console.WriteLine(printer.PrintWrongAnswer(hero.CardBox.CardsCount));
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
