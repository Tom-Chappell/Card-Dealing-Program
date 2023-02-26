using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        Pack pack;

        public Testing()
        {
            pack = new Pack();

            pack.shuffleCardPack(1, 1);
            pack.shuffleCardPack(2, 5);
            pack.shuffleCardPack(3, 1);

            Card cardSingle = pack.deal();

            List<Card> cardCollection = pack.dealCard(4);

            Console.WriteLine("Single card dealt: " + Convert.ToString(cardSingle.Value) + ", " + Convert.ToString(cardSingle.Suit));

            Console.WriteLine("Collection of cards dealt:");
            foreach (Card card in cardCollection)
            {
                Console.WriteLine(Convert.ToString(card.Value) + ", " + Convert.ToString(card.Suit));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Testing test = new Testing();
            Console.ReadLine();
        }
    }
}
