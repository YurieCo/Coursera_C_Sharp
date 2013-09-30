using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //prompt and read gamertag
            Console.Write("Enter gamertag: ");
            string gamertag = Console.ReadLine();

            //prompt and read level
            Console.Write("ENTER LEVEL: ");
            int level = int.Parse(Console.ReadLine());


            //extract first char of gamertag
            char firstGamertagChar = gamertag[0];



            //print valuues
            Console.WriteLine();
            Console.WriteLine("gamertag: " + gamertag);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("first gamertag char: " + firstGamertagChar);
            Console.WriteLine();
        }
    }
}
