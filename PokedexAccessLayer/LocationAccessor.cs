using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexAccessLayer 
{
    public class LocationAccessor : ILocationAccessor
    {
        public List<Locations> GetLocations(String gameName)
        {

            List<Locations> locationList = new List<Locations>();

            var dexConn = PokedexDBConnection.GetConnection();

            var cmd = new SqlCommand("sp_get_locations", dexConn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Location", SqlDbType.NVarChar, 1000);

            cmd.Parameters["@Location"].Value = gameName;

            
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Locations _location = new Locations();
                        _location.Name = reader.GetString(0);
                        _location.gameName = reader.GetString(1);


                        locationList.Add(_location);

                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return locationList;

        }
    }
}
