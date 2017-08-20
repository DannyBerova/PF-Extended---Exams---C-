namespace _03.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"^(\<\[[^A-Za-z0-9]*\][\.]{1})+([\.]{1}\[[A-Za-z0-9]*\][\.]{1})*$";

            Regex regex = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "Traincode!")
            {
                Match train = regex.Match(inputLine);

                if (train.Success)
                {
                    Console.WriteLine(train.Value.ToString());
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}