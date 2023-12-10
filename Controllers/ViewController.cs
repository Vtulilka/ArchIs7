using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Controllers
{
    public class ViewController
    {
        private DataBaseController DB = new DataBaseController();
        public void PrintPokemonOwners()
        {
            Console.WriteLine();
            Console.WriteLine("Выберите номер покемона");
            Guid pokemonId = new Guid();
            List<Models.Pokemons> pokemons = DB.SelectAll();
            int ind = 0;
            foreach (Models.Pokemons pokemon in pokemons)
            {
                Console.WriteLine();
                Console.WriteLine(ind + " " + pokemon.Name);
                Console.WriteLine();
                ind++;
            }
            Console.WriteLine();
            string ch = Console.ReadLine();
            Console.WriteLine();

            try
            {
                ind = int.Parse(ch);
                try
                {
                    pokemonId = pokemons[ind].Id;
                    List<Models.PokemonOwners> owners = DB.PokemonOwners(pokemonId);
                    foreach (Models.PokemonOwners owner in owners)
                    {
                        Console.WriteLine();
                        Console.WriteLine(owner.Id + " " + owner.Name);
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
        }
        public void PrintOwners()
        {
            foreach (Models.PokemonOwners owner in DB.SelectAllOwners())
            {
                Console.WriteLine();
                Console.WriteLine(owner.Id + " " + owner.Name);
                Console.WriteLine();
            }
        }
        public void PrintPokemons()
        {
            foreach (Models.Pokemons pokemon in DB.SelectAll())
            {
                Console.WriteLine();
                Console.WriteLine(pokemon.Name);
                Console.WriteLine(pokemon.Type);
                Console.WriteLine();
            }
        }
    }
}
