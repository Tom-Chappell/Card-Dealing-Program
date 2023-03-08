using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class FrontEnd // new class to allow the user to perform actions manually
    {
        Pack pack;

        public FrontEnd()
        {
            pack = new Pack();
        }

        public void run()
        {
            string userInput;
            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("[D]eal");
                Console.WriteLine("Deal [M]ultiple");
                Console.WriteLine("[F]isher-Yates shuffle");
                Console.WriteLine("[R]iffle shuffle");
                Console.WriteLine("[N]o shuffle");
                Console.WriteLine("[T]est functionality");
                Console.WriteLine("[E]xit");
                Console.WriteLine("-----------------------");
                userInput = Console.ReadLine().ToLower();

                Console.Clear();
                switch (userInput)
                {
                    case "d":
                        Card cardSingle = pack.deal();
                        Console.WriteLine("\nSingle card dealt: " + Convert.ToString(cardSingle.value) + ", " + Convert.ToString(cardSingle.suit));
                        break;
                    case "m":
                        try
                        {
                            Console.WriteLine("Amount of cards to deal:");
                            int cardAmount = Convert.ToInt32(Console.ReadLine());

                            List<Card> cardCollection = pack.dealCard(cardAmount);
                            if (cardCollection.Count != 0) Console.WriteLine("\nCollection of cards dealt:");
                            foreach (Card card in cardCollection)
                            {
                                Console.WriteLine(Convert.ToString(card.value) + ", " + Convert.ToString(card.suit));
                            }
                        }
                        catch { }
                        break;
                    case "f":
                        pack.shuffleCardPack(1);
                        Console.WriteLine("Fisher-Yates shuffle performed");
                        break;
                    case "r":
                        pack.shuffleCardPack(2);
                        Console.WriteLine("Riffle shuffle performed");
                        break;
                    case "n":
                        pack.shuffleCardPack(3);
                        Console.WriteLine("No shuffle performed");
                        break;
                    case "t": // tests each pack function
                        Test testClass = new Test();
                        testClass.test();
                        break;
                    case "e":
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
