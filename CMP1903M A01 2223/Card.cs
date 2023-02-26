using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        public int value { get; private set; } // 1 - 13
        public int suit { get; private set; } // 1 - 4

        public Card(int v, int s)
        {
            setValue(v);
            setSuit(s);
        }

        public void setValue(int v) // validates value
        {
            if (1 <= v && v <= 13) value = v;
            else value = -1;
        }

        public void setSuit(int s) // validates suit
        {
            if (1 <= s && s <= 4) suit = s;
            else suit = -1;
        }
    }
}
