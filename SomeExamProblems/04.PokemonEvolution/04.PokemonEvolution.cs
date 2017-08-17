
namespace _04.PokemonEvolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Pokemon
    {
        public string Name { get; set; }

        public string EvoType { get; set; }

        public long EvoIndex { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<Pokemon>> pokemons = new Dictionary<string, List<Pokemon>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "wubbalubbadubdub")
            {
                string[] inputParams = inputLine.Trim()
                    .Split(new[] { " -> " }, StringSplitOptions.None).ToArray();

                if (inputParams.Length == 1 && pokemons.ContainsKey(inputParams[0]))
                {
                    foreach (var pokemon in pokemons.Where(p => p.Key == inputParams[0]))
                    {
                        Console.WriteLine($"# {pokemon.Key}");

                        List<Pokemon> recents = pokemon.Value.ToList();
                        foreach (var recent in recents)
                        {
                            Console.WriteLine($"{recent.EvoType} <-> {recent.EvoIndex}");
                        }

                    }
                }
                else if(inputParams.Length > 2)
                {
                    string name = inputParams[0].Trim();
                    string evoType = inputParams[1].Trim();
                    long evoIndex = long.Parse(inputParams[2].Trim());

                    Pokemon currentPokemon = new Pokemon
                    {
                        Name = name,
                        EvoType = evoType,
                        EvoIndex = evoIndex
                    };

                    if (!pokemons.ContainsKey(name))
                    {
                        pokemons[name] = new List<Pokemon>();
                    }

                    pokemons[name].Add(currentPokemon);
                }

                inputLine = Console.ReadLine();
            }

            if (pokemons.Count > 0)
            {
                foreach (var pokemon in pokemons)
                {
                    Console.WriteLine($"# {pokemon.Key}");

                    List<Pokemon> recentPokemons = pokemon.Value.OrderByDescending(r => r.EvoIndex).ToList();

                    foreach (var sorted in recentPokemons)
                    {
                        Console.WriteLine($"{sorted.EvoType} <-> {sorted.EvoIndex}");
                    }
                }
            }
            
        }
    }
}
