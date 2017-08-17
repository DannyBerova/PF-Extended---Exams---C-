using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> pokemons = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();
            int pokemonIndex = int.Parse(Console.ReadLine());

            long sumOfRemovedElements = 0;

            while (true)
            {
                if (pokemonIndex >= pokemons.Count)
                {
                    sumOfRemovedElements += pokemons[pokemons.Count - 1];
                    long valueOfPokemon = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];

                    pokemons = IncreaseAndDecreaseValuesOfTheList(pokemons, valueOfPokemon);
                }
                else if (pokemonIndex < 0)
                {
                    sumOfRemovedElements += pokemons[0];
                    long valueOfPokemon = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];

                    pokemons = IncreaseAndDecreaseValuesOfTheList(pokemons, valueOfPokemon);
                }
                else
                {
                    sumOfRemovedElements += pokemons[pokemonIndex];
                    long valueOfPokemon = pokemons[pokemonIndex];
                    pokemons.RemoveAt(pokemonIndex);

                    pokemons = IncreaseAndDecreaseValuesOfTheList(pokemons, valueOfPokemon);
                }
                if (pokemons.Count == 0)
                {
                    break;
                }

                pokemonIndex = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sumOfRemovedElements);
        }

        private static List<long> IncreaseAndDecreaseValuesOfTheList(List<long> pokemons, long valueOfPokemon)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                
                if (pokemons[i] <= valueOfPokemon)
                {
                    pokemons[i] += valueOfPokemon;
                }
                else
                {
                    pokemons[i] -= valueOfPokemon;
                }
            }

            return pokemons;
        }
    }
}
