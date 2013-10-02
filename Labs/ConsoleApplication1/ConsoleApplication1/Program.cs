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
            Console.Write("pick up? y/n? ");
            char answer = Console.ReadLine()[0];

            //print ,message
            switch (answer)
            {
                case 'y':
                case 'Y':
                    Console.WriteLine("yea");
                    break;
                case 'n':
                case 'N':
                    Console.WriteLine("nope");
                    break;
                default:
                    Console.WriteLine("oh...");
                    break;
            }

            //print
            Console.WriteLine();
        }
    }
}
