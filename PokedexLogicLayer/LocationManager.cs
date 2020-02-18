using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokedexAccessLayer;
using PokedexDataObjects;

namespace PokedexLogicLayer
{
    public class LocationManager : ILocationManager
    {



        private ILocationAccessor _locationAccessor;

        public LocationManager()
        {
            try
            {
                _locationAccessor = new LocationAccessor();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Locations> RetrieveLocations(string gameName)
        {
            try
            {
                return _locationAccessor.GetLocations(gameName);
            }
            catch (Exception)
            {
                throw new ApplicationException("Pokedex entry is not available");
            }
        }
    }
}
