namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PokemonOwners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 8),
                        Name = c.String(nullable: false),
                        PokemonId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pokemons", t => t.PokemonId)
                .Index(t => t.PokemonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PokemonOwners", "PokemonId", "dbo.Pokemons");
            DropIndex("dbo.PokemonOwners", new[] { "PokemonId" });
            DropTable("dbo.PokemonOwners");
        }
    }
}
