using PokedexDataObjects;
using System.Collections.Generic;

namespace PokedexAccessLayer
{
    public interface IPokedexAccessor
    {
        //Fill dex page
        List<Pokemon> SelectAllPokemon();

        //Filters for dex page
        List<Pokemon> SelectPokemonByRegion(string Region);
        List<Pokemon> SelectPokemonByType(string Type);
        List<Pokemon> SelectPokemonByType2(string Type2);
        List<Pokemon> SelectPokemonByRegionAndType(string Region, string type);
        List<Pokemon> SelectPokemonByRegionAndType2(string Region, string type2);
        List<Pokemon> SelectPokemonByTypeAndType2(string Type, string Type2);
        List<Pokemon> SelectPokemonByTypeType2AndRegion(string Region, string Type, string Type2);


        //Retrieve all the different types of alternates
        List<Pokemon> SelectAllAlternateForms();

        //Retrieve just normal alternates
        List<Pokemon> SelectAllAlternates();

        //Retrieve all shinies
        List<Pokemon> SelectAllShinies();

        //Retrieve all megas
        List<Pokemon> SelectAllMega();

        //Retrieve all regionals
        List<Pokemon> SelectAllRegionals();

        //Retrieves pokemon related to user
        List<Pokemon> SelectMyPokemon(int UserID);
        List<Pokemon> SelectMyShinyPokemon(int UserID);
        List<Pokemon> SelectMyRegionalPokemon(int UserID);
        List<Pokemon> SelectMyAlternatePokemon(int UserID);
        List<Pokemon> SelectMyMegaPokemon(int UserID);

        //Selects alternate pokemon
        List<Pokemon> SelectAlternateVersions(int PokemonNumber);

        //Selects alternate stats
        PokedexEntry SelectAlternateStats(string AlternateName);

        //Adds new pokemon to users list
        void StorePokemon(int PokemonNumber, int UserID);
        void StoreMegaPokemon(int PokemonNumber, int UserID);
        void StoreShinyPokemon(int PokemonNumber, int UserID);
        void StoreAlternatePokemon(int PokemonNumber, int UserID);
        void StoreRegionalPokemon(int PokemonNumber, int UserID);


        //Removes pokemon from users list
        void RemovePokemon(int PokemonNumber, int UserID);
        void RemoveMegaPokemon(int PokemonNumber, int UserID);
        void RemoveShinyPokemon(int PokemonNumber, int UserID);
        void RemoveAlternatePokemon(int PokemonNumber, int UserID);
        void RemoveRegionalPokemon(int PokemonNumber, int UserID);


    }
}
