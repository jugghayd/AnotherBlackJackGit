using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherBlackJack
{
    public class Player
    {
        // Should have Hit(), Stand(), bool Bust
        public List<Card> Hand = new List<Card>();
        public int handTotal = 0;
        public int money { get; set; }
        public string name { get; set; }

        public Player(string n, int i) // you will want a constructor
        {
            name = n;
            money = i;
            handTotal = 0;
        }

        public int SumHand(List<Card> c) // make this a method
        {
            return Hand.Sum(Card => Card.value);
        }

        /*
        public void Hit()
        {
            Player.Hand.Add(Deck.DealCard());
        }
        */
        
    }

    /*
    public class Dealer : Player
    {
        // Dealer should have the DealCard
        // Dealer should be able to do 
        public Dealer(string n, int i)
        {
            name = n;
            money = i;
        }
    }
    */
    

    //public List<Card> Hand = new List<Card>();
}
