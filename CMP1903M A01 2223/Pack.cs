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

        public Pack() //Initialises the card pack
        {
            for (int j = 1; j < 5; j++)
            {
                for (int i = 1; i < 14; i++)
                {
                    pack.Add(new Card(i, j));
                }
            }
        }

        public bool shuffleCardPack(int typeOfShuffle, int shuffleIterations) // shuffles pack based on shuffle type
        {
            List<Card> shuffledPack = new List<Card>(pack);

            for (int shuffle = 0; shuffle < shuffleIterations; shuffle++)
            {
                switch (typeOfShuffle)
                {
                    case 1: // Fisher-Yates
                        for (int i = shuffledPack.Count - 1; i > 0; i--)
                        {
                            Random r = new Random();
                            int j = r.Next(0, i);
                            Card tempCard = shuffledPack[i];
                            shuffledPack[i] = shuffledPack[j];
                            shuffledPack[j] = tempCard;
                        }
                        break;

                    case 2: // Riffle
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

                    case 3: // No shuffle
                        break;

                    default:
                        // INVALID SHUFFLE SELECTED
                        return false;
                }
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
            else
            {
                // NOT ENOUGH CARDS LEFT
                return new Card(0 ,0);
            }
        }

        public List<Card> dealCard(int amount) // deals the number of cards specified by 'amount'
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
            else
            {
                // NOT ENOUGH CARDS LEFT
                return new List<Card>();
            }
        }
    }
}
