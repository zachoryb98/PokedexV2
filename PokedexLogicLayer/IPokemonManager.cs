using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLogicLayer
{
    interface IPokemonManager
    {
        //Retrieve all normal pokemon
        List<Pokemon> RetrieveAllPokemon();

        //Retrieve all the different types of alternates
        List<Pokemon> RetrieveAllAlternateForms();

        //Retrieve just normal alternates
        List<Pokemon> RetrieveAllAlternates();

        //Retrieve all shinies
        List<Pokemon> RetrieveAllShinies();

        //Retrieve all megas
        List<Pokemon> RetrieveAllMega();

        //Retrieve all regionals
        List<Pokemon> RetrieveAllRegionals();

        List<Pokemon> RetrieveMyPokemon(int UserID);

        List<Pokemon> RetrieveMyShinyPokemon(int UserID);
        List<Pokemon> RetrieveMyAlternatePokemon(int UserID);
        
        List<Pokemon> RetrieveMyRegionalPokemon(int UserID);        
        List<Pokemon> RetrieveMyMegaPokemon(int UserID);

        List<Pokemon> RetrieveAlternateVersions(int PokemonNumber);

        PokedexEntry RetrieveAlternateVersionStats(string AlternateName);

        void StoreNormalPokemon(int PokemonNumber, int UserID);
        void StoreShinyPokemon(int PokemonNumber, int UserID);
        void StoreMegaPokemon(int PokemonNumber, int UserID);
        void StoreRegionalPokemon(int PokemonNumber, int UserID);
        void StoreAlternatePokemon(int PokemonNumber, int UserID);
        void RemovePokemon(int PokemonNumber, int UserID);
        void RemoveMegaPokemon(int PokemonNumber, int UserID);
        void RemoveShinyPokemon(int PokemonNumber, int UserID);
        void RemoveAlternatePokemon(int PokemonNumber, int UserID);
        void RemoveRegionalPokemon(int PokemonNumber, int UserID);


        //Filters for dex page
        List<Pokemon> RetrievePokemonByRegion(string Region);
        List<Pokemon> RetrievePokemonByType(string Type);
        List<Pokemon> RetrievePokemonByType2(string Type2);
        List<Pokemon> RetrievePokemonByRegionAndType(string Region, string type);
        List<Pokemon> RetrievePokemonByRegionAndType2(string Region, string type2);
        List<Pokemon> RetrievePokemonByTypeAndType2(string Type, string Type2);
        List<Pokemon> RetrievePokemonByTypeType2AndRegion(string Region, string Type, string Type2);


    }
}
