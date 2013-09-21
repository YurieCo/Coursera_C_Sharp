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
            Console.Write("Please provide total gold you've collected in the game: ");
            int gold = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Points/sec: " + gold);
            

        }
    }
}
