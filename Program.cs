using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;



namespace AnotherBlackJack
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            Game g = new Game();
            while (true)
            {
                g.BlackJack();
                Console.WriteLine("Would you like to play again?");
                if (!Console.ReadLine().StartsWith("Y", StringComparison.OrdinalIgnoreCase))
                    break;
            }

        }
    }
}