using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.DataBase
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext() : base("name=PokemonsDataBase")
        {
        }
        public DbSet<Models.Pokemons> Pokemons { get; set; }
        public DbSet<Models.PokemonOwners> PokemonOwners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Pokemons>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Models.Pokemons>().HasMany(p => p.PokemonOwner).WithOptional(p => p.Pokemons).HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<Models.PokemonOwners>().Property(p => p.Id).HasMaxLength(8);
            modelBuilder.Entity<Models.PokemonOwners>().ToTable("PokemonOwners");
        }
    }
}
