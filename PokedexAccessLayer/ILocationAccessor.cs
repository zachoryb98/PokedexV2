using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexAccessLayer
{
    public interface ILocationAccessor
    {

        List<Locations> GetLocations(String gameName);

    }
}
