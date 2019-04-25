using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnotherBlackJack
{
    public class Game
    {
        public void BlackJack()
        {
            bool GameContinues = true;

            while (GameContinues) { 
                #region Initialize Deck and Deal

                Player player1 = new Player("Christian", 100);
                Player dealer = new Player("The Dealer", 100);

                List<Card> playerHand = new List<Card>();
                List<Card> dealerHand = new List<Card>();


                Deck newDeck = new Deck();
                newDeck.Shuffle();


                Console.WriteLine("Dealing cards...");
                Console.WriteLine();



                player1.Hand.Add(newDeck.DealCard());
                dealer.Hand.Add(newDeck.DealCard());
                player1.Hand.Add(newDeck.DealCard());
                dealer.Hand.Add(newDeck.DealCard());
                Thread.Sleep(1000);

                #endregion


                #region Player's Choice

                Console.WriteLine("Player is holding cards: ");
                foreach (Card c in player1.Hand)
                {
                    Console.WriteLine(c);
                }

                player1.SumHand(player1.Hand);

                // Why doesn't this work? 
                // int playerTotal = player1.SumHand(player1.Hand);

                // Bust can be reduced down to a function checkForBust
                bool isBust(int total)
                {
                    return total > 21;
                }

                if (isBust(player1.SumHand(player1.Hand)))
                {
                    Console.WriteLine("BUST! You lose!");
                    GameContinues = false;
                    break;
                }

                while (!isBust(player1.handTotal))
                {
                    Console.Write("Would you like to hit or stand?  ");
                    string hitOrStand = Console.ReadLine();

                    if (hitOrStand.ToLower() == "hit")
                    {

                        player1.Hand.Add(newDeck.DealCard());
                        player1.SumHand(player1.Hand); ;
                        Console.WriteLine();
                        Console.WriteLine("Player is holding cards: ");
                        foreach (Card c in player1.Hand)
                        {
                            Console.WriteLine(c);
                        }

                        /*
                        if (isBust(player1.SumHand(player1.Hand)))
                        {
                            Console.WriteLine("BUST! You lose!");
                            GameContinues = false;
                            break;
                            // EndGame function goes here -- Play again
                        }
                        */
                    }
                    else
                    {
                        // Stand
                        break;
                    }
                }

                Console.WriteLine(player1.name + "'s cards total up to " + player1.SumHand(player1.Hand));

                #endregion


                Console.WriteLine();


                #region Dealer's "Choice"


                int dealerTotal = dealer.Hand.Sum(Card => Card.value);

                // What's wrong with this? 
                bool dealerBust = dealerTotal > 21;

                while (dealerTotal <= 16)
                {
                    dealer.Hand.Add(newDeck.DealCard());

                    dealerTotal = dealer.Hand.Sum(Card => Card.value);
                    if (dealerTotal > 21)
                    {
                        Console.WriteLine("Dealer BUSTS! You win!");
                        GameContinues = false;
                        break;
                        // EndGame function goes here -- Play again
                    }

                    Console.WriteLine("Dealer's cards: ");
                    foreach (Card c in dealer.Hand)
                    {
                        Console.WriteLine(c + " ");
                    }
                    Console.WriteLine();
                }
                

                #endregion


                #region End of game result
                if (player1.SumHand(player1.Hand) > 21)
                {
                    // EndGame function goes here -- Play again -- Not needed?
                    
                }

                else if (player1.SumHand(player1.Hand) > dealerTotal)
                {
                    Console.WriteLine("Player 1 has " + player1.SumHand(player1.Hand) + ". Dealer has " + dealerTotal);
                    Console.WriteLine("You win!");
                    // End of game
                    
                }
                else if (player1.SumHand(player1.Hand) < dealerTotal)
                {
                    Console.WriteLine("Player 1 has " + player1.SumHand(player1.Hand) + ". Dealer has " + dealerTotal);
                    Console.WriteLine("You lose!");
                    // End of Game
                    
                }
                else
                {
                    Console.WriteLine("Player 1 has " + player1.SumHand(player1.Hand) + ". Dealer has " + dealerTotal);
                    Console.WriteLine("It's a tie!");
                    // End of game
                    
                }
                GameContinues = false;
                break;
                #endregion
            }
            Console.ReadLine();
        }

    }
}
