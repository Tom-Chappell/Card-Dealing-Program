using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        List<Card> pack = new List<Card>();

        public Pack() // initialises the card pack
        {
            for (int j = 1; j < 5; j++)
            {
                for (int i = 1; i < 14; i++)
                {
                    pack.Add(new Card(i, j));
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle) // shuffles pack based on shuffle type
        {
            List<Card> shuffledPack = new List<Card>(pack);
            Random r = new Random();

            switch (typeOfShuffle)
            {
                case 1: // Fisher-Yates shuffle
                    for (int i = shuffledPack.Count - 1; i > 0; i--)
                    {
                        int j = r.Next(0, i);
                        Card tempCard = shuffledPack[i];
                        shuffledPack[i] = shuffledPack[j];
                        shuffledPack[j] = tempCard;
                    }
                    break;

                case 2: // Riffle shuffle
                    List<Card> tempPack = new List<Card>(shuffledPack);
                    int newIndex = 0;
                    if (r.Next(0, 2) == 0) // decides which deck half goes first
                    {
                        for (int i = 0; i < tempPack.Count / 2; i++)
                        {
                            shuffledPack[newIndex] = tempPack[i + tempPack.Count / 2];
                            newIndex++;
                            shuffledPack[newIndex] = tempPack[i];
                            newIndex++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < tempPack.Count / 2; i++)
                        {
                            shuffledPack[newIndex] = tempPack[i];
                            newIndex++;
                            shuffledPack[newIndex] = tempPack[i + tempPack.Count / 2];
                            newIndex++;
                        }
                    }
                    break;

                case 3: // no shuffle
                    break;

                default: // invalid shuffle ID
                    Console.WriteLine("ERROR: Invalid shuffle ID");
                    return false;
            }

            pack = shuffledPack;
            return true;
        }

        public Card deal(bool fromTop = true) // deals one card
        {
            if (pack.Count != 0)
            {
                Card dealtCard;

                int location = 0;
                if (fromTop) location = pack.Count - 1;

                dealtCard = pack[location];
                pack.RemoveAt(location);

                return dealtCard;
            }
            else // pack was empty
            {
                Console.WriteLine("ERROR: Pack was empty");
                return new Card(-1 ,-1);
            }
        }

        public List<Card> dealCard(int amount, bool fromTop = true) // deals the specified number of cards
        {
            if (amount <= pack.Count && amount > 0)
            {
                List<Card> dealtCards = new List<Card>();
                int location = 0;

                for (int i = 0; i < amount; i++)
                {
                    if (fromTop) location = pack.Count - 1;
                    dealtCards.Add(pack[location]);
                    pack.RemoveAt(location);
                }

                return dealtCards;
            }
            else // pack didn't contain the specified number of cards
            {
                if (pack.Count == 0) Console.WriteLine("ERROR: Pack was empty");
                else if (amount <= 0) Console.WriteLine("ERROR: Requested cards was below 1");
                else Console.WriteLine("ERROR: There are not " + Convert.ToString(amount) + " card(s) remaining in the deck");
                return new List<Card>();
            }
        }
    }
}
