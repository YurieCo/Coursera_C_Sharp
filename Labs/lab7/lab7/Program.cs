using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("month is your birthday? ");
            string answerMonth = Console.ReadLine();
            Console.Write("day is your birthday? ");
            int answerDay = int.Parse(Console.ReadLine());
            Console.Write("You’ll receive an email reminder on " + answerMonth + " " + (answerDay-1));
            Console.WriteLine();
        }
    }
}
