using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoreData loreData = new LoreData();
            loreData.SetLoreDataToList();

            int loreStep = 0;
            int writeNumber = 0;
            for (int step = loreStep; step <= LoreData.QuestionStep; step++)
            {
                Console.WriteLine(loreData.LoreLineList[step]);
                Console.Read();
                loreStep++;
            }
            do
            {
                Console.WriteLine(loreData.QuestionText);
                writeNumber = ReadNumber(Console.ReadLine());
                if (CheckNumber(LoreData.QuestionCount, writeNumber))
                {
                    Console.WriteLine(loreData.AnswerList[writeNumber]);
                }
                else
                {
                    Console.WriteLine($"Введите число от 1 до {LoreData.QuestionCount}");
                }
            }
            while (writeNumber != LoreData.QuestionCount - 1);
            for (int step = loreStep; step < loreData.LoreLineList.Count; step++)
            {
                Console.WriteLine(loreData.LoreLineList[step]);
            }

            Beast beast;
            BeastCreator beastCreator = new BeastCreator();

            Console.Write("Введите Ваше имя:");
            Hero mainHero = new Hero(Console.ReadLine());
            mainHero.GetCardPack();
            bool endGame = false;
            do
            {
                beast = null;
                beast = beastCreator.CreateRandomBeast();
                Console.WriteLine($"К вам приближается {beast.Name}");
                Console.WriteLine(FighterInfo.GetBeastInfo(beast));
                do
                {
                    Console.WriteLine(LoreData.HeroAction);
                    writeNumber = ReadNumber(Console.ReadLine());
                    if (CheckNumber(LoreData.ActionCount, writeNumber))
                    {
                        if (writeNumber == 0) // attack
                        {
                            Console.WriteLine("Выберите карту");
                            Console.WriteLine(mainHero.Casket.GetCardListToString());
                            int cardNumber = ReadNumber(Console.ReadLine());
                            int cardCount = mainHero.Casket.GetCardCount();
                            if (CheckNumber(cardCount, cardNumber))
                            {
                                BattleManager battleManager = new BattleManager();
                                Card card = mainHero.Casket.GetCard(cardNumber);
                                if (battleManager.ToBattle(card, beast))
                                {
                                    Console.WriteLine($"Карта {card.Name} одолела зверя {beast.Name}!!");
                                    float score = 10;
                                    mainHero.AddScore(score);
                                    Console.WriteLine($"Начислено {score} очков");
                                }
                                else
                                {
                                    Console.WriteLine("Вы не справились с опасностей. Зверь оказался сильнее");
                                    endGame = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Введите число от 1 до {cardCount}");
                            }
                        }
                        else if (writeNumber == 1) //conversate
                        {
                            Console.WriteLine("Выберите карту");
                            Console.WriteLine(mainHero.Casket.GetCardListToString());
                            int cardNumber = ReadNumber(Console.ReadLine());
                            int cardCount = mainHero.Casket.GetCardCount();
                            if (CheckNumber(cardCount, cardNumber))
                            {
                                Card card = mainHero.Casket.GetCard(cardNumber);
                                card.TryToConversate(beast);
                                if (beast.IsConversatable)
                                {
                                    Console.WriteLine($"Вы смогли убедить зверя {beast.Name}! Победа!!");
                                    float score = 10;
                                    mainHero.AddScore(score);
                                    Console.WriteLine($"Вы получили {score} очков");
                                }
                                else
                                {
                                    Console.WriteLine($"Зверь {beast.Name} не понял ваших слов... Битва проиграна");
                                    endGame = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Введите число от 1 до {cardCount}");
                            }
                        }
                        else if (writeNumber == 2) // Info
                        {
                            for (int index = 0; index < mainHero.Casket.GetCardCount(); index++)
                            {
                                Console.WriteLine(FighterInfo.GetCardInfo(mainHero.Casket.GetCard(index)));
                            }
                        }
                        else //swap
                        {
                            Console.WriteLine("Выберите карту");
                            Console.WriteLine(mainHero.Casket.GetCardListToString());
                            int cardNumber = ReadNumber(Console.ReadLine());
                            int cardCount = mainHero.Casket.GetCardCount();
                            if (CheckNumber(cardCount, cardNumber))
                            {
                                mainHero.Casket.SwapCardToRandom(cardNumber);
                                Console.WriteLine("Карта изменена");
                            }
                            else
                            {
                                Console.WriteLine($"Введите число от 1 до {cardCount}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Введите число от 1 до {LoreData.ActionCount}");
                    }
                } while (!endGame && !beast.IsDead && !beast.IsConversatable);
            } while (!endGame);
            Console.WriteLine($"Получено очков: {mainHero.Score}");

            Console.ReadLine();
        }

        private static int ReadNumber(string number)
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

        private static bool CheckNumber(int count, int index)
        {
           return index < 0 && index >= count;
        }
    }
}
