using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace asses_1
{
    /// <summary>
    /// This is a programming assignment for "Beginning Game Programming with C#"
    /// The program does the following: 
    /// Imagine you’re developing a game that keeps statistics about player performance. 
    /// Everyone wants to be able to see how much gold they've earned.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //welcome message
            Console.WriteLine("Welcome! This app calculates your average gold-collecting performance");
            // Prompt 
            Console.Write("Please provide total gold collected in the game: ");
            int gold = int.Parse(Console.ReadLine());
            Console.WriteLine();
            //Prompt the user for the total number of hours they've played the game
            Console.Write("Please provide total number of hours played: ");
            float hours = float.Parse(Console.ReadLine());
            //Convert the hours to minutes
            int totalMinsPlayed = hours * 60;
            //Calculate the gold per minute statistic
            float goldperMin = gold / totalMinsPlayed;
            //Print out the gold, hours played, and gold per minute statistics
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("gold gathered: " + gold);
            Console.WriteLine("hours played: " + gold);
            Console.WriteLine("gold per minute: " + totalMinsPlayed);
            

        }
    }
}
