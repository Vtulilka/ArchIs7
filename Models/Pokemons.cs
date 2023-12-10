using System;
using System.Collections.Generic;

namespace Lab6.Models
{
    public class Pokemons
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ICollection<PokemonOwners> PokemonOwner { get; set; }
        public Pokemons()
        {
            PokemonOwner = new List<PokemonOwners>();
        }
    }
}
