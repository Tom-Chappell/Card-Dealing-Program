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

            switch (typeOfShuffle)
            {
                case 1: // Fisher-Yates shuffle
                    for (int i = shuffledPack.Count - 1; i > 0; i--)
                    {
                        Random r = new Random();
                        int j = r.Next(0, i);
                        Card tempCard = shuffledPack[i];
                        shuffledPack[i] = shuffledPack[j];
                        shuffledPack[j] = tempCard;
                    }
                    break;

                case 2: // Riffle shuffle
                    List<Card> tempPack = new List<Card>(shuffledPack);
                    int newIndex = 0;

                    for (int i = 0; i < tempPack.Count / 2; i++)
                    {
                        shuffledPack[newIndex] = tempPack[i + tempPack.Count / 2];
                        newIndex++;
                        shuffledPack[newIndex] = tempPack[i];
                        newIndex++;
                    }
                    break;

                case 3: // no shuffle
                    break;

                default: // invalid shuffle ID
                    return false;
            }

            pack = shuffledPack;
            return true;
        }

        public Card deal() // deals one card
        {
            if (pack.Count != 0)
            {
                Card dealtCard;

                dealtCard = pack[0];
                pack.RemoveAt(0);

                return dealtCard;
            }
            else // pack was empty
            {
                return new Card(-1 ,-1);
            }
        }

        public List<Card> dealCard(int amount) // deals the specified number of cards
        {
            if (amount <= pack.Count)
            {
                List<Card> dealtCards = new List<Card>();

                for (int i = 0; i < amount; i++)
                {
                    dealtCards.Add(pack[0]);
                    pack.RemoveAt(0);
                }

                return dealtCards;
            }
            else // pack didn't contain the specified number of cards
            {
                return new List<Card>();
            }
        }
    }
}
