using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide Pyramid Slot Number. should be as:");
            Console.WriteLine("<pyramid slot number>,<block letter>,<block lit or not>");
            string answerUser = Console.ReadLine();

            //find comma location
            int commaLocation = answerUser.IndexOf(",");

            //extract pyramid slot number
            int pyramidSlotNum = int.Parse(answerUser.Substring(0, commaLocation));
            
            //print pyramid slot number
            Console.Write("pyramid slot number is : " + pyramidSlotNum);
            
            Console.WriteLine();
            
            //find 2nd comma location
            commaLocation = (answerUser.Substring(commaLocation + 1).IndexOf(",")) + commaLocation;
            //print the block letter
            string pyramidBlock = answerUser.Substring(commaLocation, 1);
            //print block letter
            Console.Write("block letter is : " + pyramidBlock);
            
            Console.WriteLine();
            
            //get the bool
            string pyramidBool = answerUser.Substring(commaLocation+2);
            //print bool
            Console.Write("bool is : " + pyramidBool);

            Console.WriteLine();
        }
    }
}
