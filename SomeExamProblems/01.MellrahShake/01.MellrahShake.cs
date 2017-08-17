using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.MellrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            int firstOccurence = input.IndexOf(pattern);
            int lastOccurence = input.LastIndexOf(pattern);

            while (firstOccurence != -1 && lastOccurence != -1 && pattern != string.Empty)
            {

                input = input.Remove(lastOccurence, pattern.Length);
                input = input.Remove(firstOccurence, pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);
                Console.WriteLine("Shaked it.");

                firstOccurence = input.IndexOf(pattern);
                lastOccurence = input.LastIndexOf(pattern);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }
    }
}
