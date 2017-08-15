﻿namespace _04.WormsWorldParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            var wormsParty = new Dictionary<string, Dictionary<string, long>>();
            List<string> names = new List<string>();

            string input = Console.ReadLine();

            while (input != "quit")
            {
                string[] inputTokens = input
                    .Split(new string[] { " -> " }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string name = inputTokens[0];
                string team = inputTokens[1];
                int score = int.Parse(inputTokens[2]);

                if (names.Contains(name))
                {
                    input = Console.ReadLine();
                    continue;
                }

                names.Add(name);

                if (!wormsParty.ContainsKey(team))
                {
                    wormsParty[team] =  new Dictionary<string, long>();
                    
                }

                if (!wormsParty[team].ContainsKey(name))
                {
                    wormsParty[team][name] = score;
                }
                
                input = Console.ReadLine();
            }

            var orderedWormsParty = wormsParty.OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(x => x.Value.Values.Sum() / x.Value.Values.Count);

            int count = 1;

            foreach (KeyValuePair<string, Dictionary<string, long>> kvp in orderedWormsParty)
            {
                string name = kvp.Key;
                Dictionary<string, long> worms = kvp.Value;
                long total = worms.Values.Sum();
                Console.WriteLine($"{count}. Team: {name} - {total}");

                foreach (var pair in worms.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{pair.Key} : {pair.Value}");
                }
                count++;
            }
        }
    }
}
