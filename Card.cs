using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherBlackJack
{
    public class Card
    {
        public string face; // Declare a string; could change this to int?
        public string suit; // Declare a string for the name of the suit
        public int value { get; }

        public Card(string cardFace, string cardSuit)
        {
            face = cardFace;
            suit = cardSuit;
            value = getCardValue(cardFace);
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }

        static int getCardValue(string s)
        {
            switch (s)
            {
                case "Two":
                    return 2;

                case "Three":
                    return 3;

                case "Four":
                    return 4;

                case "Five":
                    return 5;

                case "Six":
                    return 6;

                case "Seven":
                    return 7;

                case "Eight":
                    return 8;

                case "Nine":
                    return 9;

                case "Ten":
                case "Jack":
                case "Queen":
                case "King":
                    return 10;

                case "Ace":
                    return 11;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
