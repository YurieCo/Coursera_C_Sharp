using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCards;

namespace ProgrammingAssignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables for and create a deck of cards and blackjack hands for the dealer and the player
                // create a new deck 
            Console.WriteLine("----- A New deck Shuffled-----");
            Deck deck = new Deck();
            //only for check:
            //deck.Print();
            Console.WriteLine();

                //blackjack hands for the dealer
            BlackjackHand dealerHand = new BlackjackHand("dealer");

                //blackjack hands for the player
            BlackjackHand playerHand = new BlackjackHand("player");

            // Print a “welcome” message to the user telling them that the program will play a single hand of Blackjack
            Console.WriteLine("Welcome. This program will play a single hand of Blackjack");
            
            Console.WriteLine();
            
            // suffle the deck
            deck.Shuffle();

            //Take top card from deck
            Card drawCard = deck.TakeTopCard();
            //drawCard.FlipOver();
            //Console.WriteLine(drawCard.Rank + " of " + drawCard.Suit);
            // Deal 2 cards to the player and dealer
                // add card to dealer hand
            dealerHand.AddCard(drawCard);
                //Take top card from deck & add to player hand
            drawCard = deck.TakeTopCard();
            playerHand.AddCard(drawCard);
                //Take top card from deck & add to dealer hand
            drawCard = deck.TakeTopCard();
            dealerHand.AddCard(drawCard);
                //Take top card from deck & add to player hand
            drawCard = deck.TakeTopCard();
            playerHand.AddCard(drawCard);

            //Make all the player’s cards face up
            playerHand.ShowAllCards();
            
            //Make the dealer’s first card face up
            dealerHand.ShowFirstCard();

            //Print both the player’s hand and the dealer’s hand
            playerHand.Print();
            dealerHand.Print();

            //Ask player if they want to stay or hit
            playerHand.HitOrNot(deck);
            //Print player’s hand
            playerHand.Print();

            //Make the dealer’s all cards face up and print
            dealerHand.ShowAllCards();
            dealerHand.Print();

            //print scores
            Console.WriteLine("---- Score ----");
            Console.WriteLine("Player: " + playerHand.Score + " Dealer: " + dealerHand.Score);
            
            Console.WriteLine();
        }
    }
}
