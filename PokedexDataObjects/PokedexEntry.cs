using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexDataObjects
{
    public class PokedexEntry 
    {
        //Would have used View Model, Set this all up way before we learned about it.

        public int PokemonNumbers { get; set; }
        public string PokemonNames { get; set; }
        public string PokemonTypes { get; set; }
        public string PokemonTypes2 { get; set; }        
        public int PokemonHP { get; set; }
        public int PokemonAttack { get; set; }
        public int PokemonDefense { get; set; }
        public int PokemonSpecialAttack { get; set; }
        public int PokemonSpecialDefense { get; set; }
        public int PokemonSpeed { get; set; }
        public string PokemonGender { get; set; }
        public string PokemonCategory { get; set; }
        public string PokemonAbility { get; set; }
        public string PokemonAbility2 { get; set; }
        public string DexEntry { get; set; }
        public string PokemonHeight { get; set; }
        public string PokemonWeight { get; set; }
        public string PokemonImage { get; set; }
        public string Evo1 { get; set; }
        public string Evo2 { get; set; }
        public string Evo3 { get; set; }
        public string Evo4 { get; set; }
        public string Evo5 { get; set; }
        public string Evo6 { get; set; }
        public string Evo7 { get; set; }
        public string Evo8 { get; set; }
        public string Evo9 { get; set; }
    }
}
