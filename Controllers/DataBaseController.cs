using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Controllers
{
    public class DataBaseController
    {
        public void Insert(Models.Pokemons pokemons)
        {
            using (DataBase.PokemonDbContext db = new DataBase.PokemonDbContext())
            {
                db.Pokemons.Add(pokemons);
                db.SaveChanges();
            }
        }
        public List<Models.PokemonOwners> PokemonOwners(Guid PokemonId)
        {
            List<Models.PokemonOwners> owners;
            using (DataBase.PokemonDbContext db = new DataBase.PokemonDbContext())
            {
                owners = db.Pokemons.Where(s => s.Id == PokemonId)
                    .Include(s => s.PokemonOwner)
                    .First().PokemonOwner.ToList();
            }
            return owners;
        }
        public List<Models.PokemonOwners> SelectAllOwners()
        {
            List<Models.PokemonOwners> owners;
            using (DataBase.PokemonDbContext db = new DataBase.PokemonDbContext())
            {
                owners = db.PokemonOwners.ToList();
            }
            return owners;
        }

        public List<Models.Pokemons> SelectAll()
        {
            List<Models.Pokemons> pokemons1;
            using (DataBase.PokemonDbContext db = new DataBase.PokemonDbContext())
            {
                pokemons1 = db.Pokemons.ToList();
            }
            return pokemons1;
        }

    }
}
