using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexAccessLayer
{
    internal class PokedexDBConnection
    {
        private static string pokedexConnectionString = 
            
           @"Data Source=localhost\sqlexpress;Initial Catalog = PokedexDB; Integrated Security = True";

           //@"Data Source=LocalHost;Initial Catalog=PokedexDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            var dexConn = new SqlConnection(pokedexConnectionString);
            return dexConn;
        }
    }
}
