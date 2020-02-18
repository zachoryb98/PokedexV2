using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexDataObjects
{
    public class PokedexUser
    {
        public int PokedexUserID { get; set; }

        public string PokedexUserName { get; set; }

        public string Email { get; set; }

        public List<String> PokedexRoles { get; set; }

        public bool Active { get; set; }
    }
}
