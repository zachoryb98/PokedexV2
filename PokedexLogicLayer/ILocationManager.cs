using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLogicLayer
{
    interface ILocationManager
    {

        List<Locations> RetrieveLocations(String gameName);

    }
}
