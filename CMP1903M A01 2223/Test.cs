using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Test
    {
        Pack pack;

        public Test()
        {
            pack = new Pack();
        }

        public void test() // tests the pack class's methods
        {
            Console.WriteLine("Fisher-Yates: " + pack.shuffleCardPack(1));
            Console.WriteLine("Riffle: " + pack.shuffleCardPack(2));
            Console.WriteLine("No shuffle: " + pack.shuffleCardPack(3));

            Card cardSingle = pack.deal();
            List<Card> cardCollection = pack.dealCard(4);

            Console.WriteLine("\nSingle card dealt: " + Convert.ToString(cardSingle.value) + ", " + Convert.ToString(cardSingle.suit));
            if (cardCollection.Count != 0) Console.WriteLine("\nCollection of cards dealt:");
            foreach (Card card in cardCollection)
            {
                Console.WriteLine(Convert.ToString(card.value) + ", " + Convert.ToString(card.suit));
            }
        }
    }
}
