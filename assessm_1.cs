using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace first_sharp
{
    /// <summary>
    /// class that prints
    /// </summary>
    class Program
    {
        /// <summary>
        /// main method should print
        /// </summary>
        /// <param name="args">command line args</param>
        static void Main(string[] args)
        {
            //declare vars
            int score = 1356;
            int totalsecondsPlayed = 10000;

            //calc ponts/sec
            float pointspersecond = (float)score / totalsecondsPlayed;
            Console.WriteLine("Points/sec: " + pointspersecond);
            Console.WriteLine();
        }
    }
}
