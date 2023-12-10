using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace Lab6.Controllers
{
    public class HtmlController
    {
        private string html = @"https://pokemondb.net/pokedex/all";

        public List<Models.Pokemons> GetPokemons()
        {
            List<Models.Pokemons> Pokemons = new List<Models.Pokemons>();
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument Doc = new HtmlDocument();
            try
            {
                Doc = htmlWeb.Load(html);
            }
            catch
            {
                throw;
            }

            int count = 0;
            HtmlNodeCollection tr = Doc.DocumentNode.SelectNodes("//tbody/tr");
            foreach (HtmlNode td in tr)
            {
                if (count >= 10)
                    break;
                string name = td.SelectNodes(".//td[@class='cell-name']/a").First().InnerText;
                //name = name.Replace("\n", "").Replace("\r", "");
                string type = td.SelectNodes(".//td[@class='cell-icon']/a").First().InnerText;
                Models.Pokemons pokemon = new Models.Pokemons
                {
                    Name = name,
                    Type = type
                };
                Pokemons.Add(pokemon);
                count++;
            }
            return Pokemons;
        }
    }
}
