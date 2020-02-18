using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokedexDataObjects;
using PokedexAccessLayer;

namespace PokedexLogicLayer
{
    public class PokemonManager : IPokemonManager
    {
        List<Pokemon> _pokemonList;
        private IPokedexAccessor _pokedexAccessor;

        public PokemonManager()
        {
            try
            {
                _pokedexAccessor = new PokedexAccessor();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gets the _pokemonList
        public List<Pokemon> PokemonList
        {
            get { return _pokemonList; }
        }

        //Fetches the current Pokemon Entry based on the index of _pokemonList
        public PokedexEntry GetPokedexEntry(int pokemonIndex)
        {
            try
            {
                return PokedexAccessor.RetrievePokedexEntry(RetrieveAllPokemon()[pokemonIndex]);
            }
            catch (Exception)
            {
                throw new ApplicationException("Pokedex entry is not available");
            }
        }

        public void RemoveAlternatePokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.RemoveAlternatePokemon(PokemonNumber, UserID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Alternate Pokemon is not available");
            }
        }

        public void RemoveMegaPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.RemoveMegaPokemon(PokemonNumber, UserID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Mega Pokemon is not available");
            }
        }

        public void RemovePokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.RemovePokemon(PokemonNumber, UserID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Pokemon is not available");
            }
        }

        public void RemoveRegionalPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.RemoveRegionalPokemon(PokemonNumber, UserID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Regional Pokemon is not available");
            }
        }

        public void RemoveShinyPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.RemoveShinyPokemon(PokemonNumber, UserID);
            }
            catch (Exception)
            {
                throw new ApplicationException("Shiny Pokemon is not available");
            }
        }

        public List<Pokemon> RetrieveAllAlternateForms()
        {
            try
            {
                return _pokedexAccessor.SelectAllAlternateForms();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Alternate Forms Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAllAlternates()
        {
            try
            {
                //One that does not return all of them
                return _pokedexAccessor.SelectAllAlternates();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Alternates Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAllMega()
        {
            try
            {
                return _pokedexAccessor.SelectAllMega();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Mega Pokemon Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAllPokemon()
        {
            try
            {
                return _pokedexAccessor.SelectAllPokemon();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Pokemon Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAllRegionals()
        {
            try
            {
                return _pokedexAccessor.SelectAllRegionals();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Regional Pokemon Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAllShinies()
        {
            try
            {
                return _pokedexAccessor.SelectAllShinies();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Shiny Pokemon Data not found.", ex);
            }
        }

        public List<Pokemon> RetrieveAlternateVersions(int PokemonNumber)
        {
            try
            {
                return _pokedexAccessor.SelectAlternateVersions(PokemonNumber);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Alternate version is not available", ex);
            }
        }

        public PokedexEntry RetrieveAlternateVersionStats(string AlternateName)
        {
            try
            {
                return _pokedexAccessor.SelectAlternateStats(AlternateName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users pokemon is not available", ex);
            }
        }

        public List<Pokemon> RetrieveMyAlternatePokemon(int UserID)
        {
            try
            {
                return _pokedexAccessor.SelectMyAlternatePokemon(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users alternate pokemon is not available", ex);
            }
        }

        public List<Pokemon> RetrieveMyMegaPokemon(int UserID)
        {
            try
            {
                return _pokedexAccessor.SelectMyMegaPokemon(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users mega pokemon is not available", ex);
            }
        }

        public List<Pokemon> RetrieveMyPokemon(int UserID)
        {
            try
            {
                return _pokedexAccessor.SelectMyPokemon(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users pokemon is not available", ex);
            }


        }

        public List<Pokemon> RetrieveMyRegionalPokemon(int UserID)
        {
            try
            {
                return _pokedexAccessor.SelectMyRegionalPokemon(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users regional pokemon is not available", ex);
            }
        }

        public List<Pokemon> RetrieveMyShinyPokemon(int UserID)
        {
            try
            {
                return _pokedexAccessor.SelectMyShinyPokemon(UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users shiny pokemon is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByRegion(string Region)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByRegion(Region);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by region is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByRegionAndType(string Region, string type)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByRegionAndType(Region, type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by region and type is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByRegionAndType2(string Region, string type2)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByRegionAndType2(Region, type2);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by region and type 2 is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByType(string Type)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByType(Type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by type is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByType2(string Type2)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByType2(Type2);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by type 2 is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByTypeAndType2(string Type, string Type2)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByTypeAndType2(Type, Type2);
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by type and type 2 is not available", ex);
            }
        }

        public List<Pokemon> RetrievePokemonByTypeType2AndRegion(string Region, string Type, string Type2)
        {
            try
            {
                return _pokedexAccessor.SelectPokemonByTypeType2AndRegion(Region, Type, Type2 );               
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of pokemon by type, type 2, and region is not available", ex);
            }
        }

        public void StoreAlternatePokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.StoreAlternatePokemon(PokemonNumber, UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users alternate pokemon is not available for storage", ex);
            }
        }

        public void StoreMegaPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.StoreMegaPokemon(PokemonNumber, UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users mega pokemon is not available for storage", ex);
            }
        }

        public void StoreNormalPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.StorePokemon(PokemonNumber, UserID);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Selection of users pokemon is not available for storage", ex);
            }
        }

        public void StoreRegionalPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.StoreRegionalPokemon(PokemonNumber, UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users regional pokemon is not available for storage", ex);
            }
        }

        public void StoreShinyPokemon(int PokemonNumber, int UserID)
        {
            try
            {
                _pokedexAccessor.StoreShinyPokemon(PokemonNumber, UserID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Selection of users shiny pokemon is not available for storage", ex);
            }
        }
    }
}
