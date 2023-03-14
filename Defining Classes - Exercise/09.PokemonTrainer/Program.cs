using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = commandArgs[0];
                string pokemonName = commandArgs[1];
                string pokemonElement = commandArgs[2];
                int pokemonHealth = int.Parse(commandArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.FirstOrDefault(name => name.Name == trainerName);

                if (trainer != null)
                {
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer newTrainer = new Trainer(trainerName);
                    newTrainer.Pokemons.Add(pokemon);
                    trainers.Add(newTrainer);
                }
            }

            string element = string.Empty;
            while ((element = Console.ReadLine()) != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Pokemons.Any(e => e.Element == element) &&
                        trainers[i].Pokemons.Count > 0)
                    {
                        trainers[i].IncreaseBadge();
                    }
                    else
                    {
                        foreach (var pokemon in trainers[i].Pokemons)
                        {
                            pokemon.DecreaseHealth();
                        }
                    }

                    trainers[i].Pokemons.RemoveAll(p => p.Health <= 0);
                }
            }

            foreach (var trainer in trainers
                .OrderByDescending(b => b.Badge))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badge} {trainer.Pokemons.Count}");
            }
        }
    }
}
