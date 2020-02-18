using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexDataObjects
{
    public class Pokemon
    {

        public int PokemonNumber { get; set; }

        public string PokemonName { get; set; }

        public string PokemonRegion { get; set; }

        public string PokemonType { get; set; }

        public string PokemonType2 { get; set; }

        public int AlternatePokemonNumber { get; set; }
    }
}
