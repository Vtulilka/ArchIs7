using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class PokemonOwners
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? PokemonId { get; set; }

        public Pokemons Pokemons { get; set; }
    }
}
