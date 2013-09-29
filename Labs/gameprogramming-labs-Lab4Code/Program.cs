using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            // create a new deck and print the contents of the deck
            Console.WriteLine("----- A New deck -----");
            Deck deck = new Deck();
            deck.Print();
            Console.WriteLine();
            // shuffle the deck and print the contents of the deck
            Console.WriteLine("----- Shuffle & print -----");
            deck.Shuffle();
            deck.Print();
            Console.WriteLine();
            // take the top card from the deck and print the card rank and suit
            Console.WriteLine("----- take the top card & print -----");
            Card card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);
            Console.WriteLine();

            // take the top card from the deck and print the card rank and suit
            Console.WriteLine("----- take another top card & print -----");
            card = deck.TakeTopCard();
            Console.WriteLine(card.Rank + " of " + card.Suit);
            Console.WriteLine();

        }
    }
}
