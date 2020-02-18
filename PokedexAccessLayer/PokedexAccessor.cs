using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokedexDataObjects;

namespace PokedexAccessLayer
{
    public class PokedexAccessor : IPokedexAccessor
    {

        // Method that files the program with data from the text files.
        public static PokedexEntry RetrievePokedexEntry(Pokemon pokemon)
        {
            //Was here for meltan and Melmetal but they caused too much trouble leaving this for now because I will use it in the future
            if (pokemon.PokemonNumber == 808 || pokemon.PokemonNumber == 809)
            {
                var dexConn2 = PokedexDBConnection.GetConnection();
                var cmd2 = new SqlCommand("sp_fill_dex_page2", dexConn2);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@PokemonNumber", SqlDbType.Int);
                cmd2.Parameters["@PokemonNumber"].Value = pokemon.PokemonNumber;
                PokedexEntry newPokedexEntry2 = new PokedexEntry();
                try
                {
                    dexConn2.Open();

                    var reader = cmd2.ExecuteReader();

                    reader.Read();


                    newPokedexEntry2.PokemonNumbers = reader.GetInt32(0);
                    newPokedexEntry2.PokemonNames = reader.GetString(1);
                    newPokedexEntry2.PokemonTypes = reader.GetString(2);
                    if (reader["PokemonType2"] == DBNull.Value)
                    {
                        newPokedexEntry2.PokemonTypes2 = "";
                    }
                    else
                    {
                        newPokedexEntry2.PokemonTypes2 = Convert.ToString(reader["PokemonType2"]);
                    }
                    newPokedexEntry2.PokemonHP = reader.GetInt32(4);
                    newPokedexEntry2.PokemonAttack = reader.GetInt32(5);
                    newPokedexEntry2.PokemonDefense = reader.GetInt32(6);
                    newPokedexEntry2.PokemonSpecialAttack = reader.GetInt32(7);
                    newPokedexEntry2.PokemonSpecialDefense = reader.GetInt32(8);
                    newPokedexEntry2.PokemonSpeed = reader.GetInt32(9);
                    newPokedexEntry2.PokemonGender = reader.GetString(10);
                    newPokedexEntry2.PokemonCategory = reader.GetString(11);
                    newPokedexEntry2.PokemonAbility = "";
                    newPokedexEntry2.PokemonAbility2 = "";
                    newPokedexEntry2.DexEntry = reader.GetString(14);
                    newPokedexEntry2.PokemonHeight = reader.GetString(15);
                    newPokedexEntry2.PokemonWeight = reader.GetString(16);
                    newPokedexEntry2.PokemonImage = reader.GetString(17);
                    newPokedexEntry2.Evo1 = Convert.ToString(reader["Evolution1"]);
                    newPokedexEntry2.Evo2 = Convert.ToString(reader["Evolution2"]);

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    dexConn2.Close();
                }

                return newPokedexEntry2;
            }
            else
            {
                var dexConn = PokedexDBConnection.GetConnection();
                var cmd = new SqlCommand("sp_fill_dex_page", dexConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
                cmd.Parameters["@PokemonNumber"].Value = pokemon.PokemonNumber;
                PokedexEntry newPokedexEntry = new PokedexEntry();

                try
                {
                    dexConn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    newPokedexEntry.PokemonNumbers = reader.GetInt32(0);
                    newPokedexEntry.PokemonNames = reader.GetString(1);
                    newPokedexEntry.PokemonTypes = reader.GetString(2);
                    if (reader["PokemonType2"] == DBNull.Value)
                    {
                        newPokedexEntry.PokemonTypes2 = "";
                    }
                    else
                    {
                        newPokedexEntry.PokemonTypes2 = Convert.ToString(reader["PokemonType2"]);
                    }
                    newPokedexEntry.PokemonHP = reader.GetInt32(4);
                    newPokedexEntry.PokemonAttack = reader.GetInt32(5);
                    newPokedexEntry.PokemonDefense = reader.GetInt32(6);
                    newPokedexEntry.PokemonSpecialAttack = reader.GetInt32(7);
                    newPokedexEntry.PokemonSpecialDefense = reader.GetInt32(8);
                    newPokedexEntry.PokemonSpeed = reader.GetInt32(9);
                    newPokedexEntry.PokemonGender = reader.GetString(10);
                    newPokedexEntry.PokemonCategory = reader.GetString(11);
                    if (reader["AbilityName"] == DBNull.Value)
                    {
                        newPokedexEntry.PokemonAbility = "";
                    }
                    else
                    {
                        newPokedexEntry.PokemonAbility = Convert.ToString(reader["AbilityName"]);
                    }
                    if (reader["AbilityName2"] == DBNull.Value)
                    {
                        newPokedexEntry.PokemonAbility2 = "";
                    }
                    else
                    {
                        newPokedexEntry.PokemonAbility2 = Convert.ToString(reader["AbilityName2"]);
                    }
                    newPokedexEntry.DexEntry = reader.GetString(14);
                    newPokedexEntry.PokemonImage = reader.GetString(15);
                    newPokedexEntry.PokemonHeight = reader.GetString(16);
                    newPokedexEntry.PokemonWeight = reader.GetString(17);
                    newPokedexEntry.Evo1 = Convert.ToString(reader["Evolution1"]);
                    if (reader["Evolution2"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo2 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo2 = Convert.ToString(reader["Evolution2"]);
                    }

                    if (reader["Evolution3"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo3 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo3 = Convert.ToString(reader["Evolution3"]);
                    }

                    if (reader["Evolution4"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo4 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo4 = Convert.ToString(reader["Evolution4"]);
                    }

                    if (reader["Evolution5"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo5 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo5 = Convert.ToString(reader["Evolution5"]);
                    }

                    if (reader["Evolution6"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo6 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo6 = Convert.ToString(reader["Evolution6"]);
                    }

                    if (reader["Evolution7"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo7 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo7 = Convert.ToString(reader["Evolution7"]);
                    }

                    if (reader["Evolution8"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo8 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo8 = Convert.ToString(reader["Evolution8"]);
                    }

                    if (reader["Evolution9"] == DBNull.Value)
                    {
                        newPokedexEntry.Evo9 = "";
                    }
                    else
                    {
                        newPokedexEntry.Evo9 = Convert.ToString(reader["Evolution9"]);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    dexConn.Close();
                }

                return newPokedexEntry;
            }

        }

        //Removes alternate pokemon from user list
        public void RemoveAlternatePokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_my_alternate_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Remove Mega Pokemon from the list
        public void RemoveMegaPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_my_mega_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Remove normal pokemon from user list
        public void RemovePokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_my_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Remove regional pokemon
        public void RemoveRegionalPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_my_regional_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Remove Shiny Pokemon
        public void RemoveShinyPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_my_shiny_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Does not return all of them
        public List<Pokemon> SelectAllAlternateForms()
        {
            List<Pokemon> AllAlternateList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_alternate_versions", dexConn);
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newAltermatePokemon = new Pokemon();
                        newAltermatePokemon.PokemonNumber = reader.GetInt32(0);
                        newAltermatePokemon.PokemonName = reader.GetString(1);
                        newAltermatePokemon.PokemonType = reader.GetString(2);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            newAltermatePokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newAltermatePokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        newAltermatePokemon.PokemonRegion = reader.GetString(4);
                        newAltermatePokemon.AlternatePokemonNumber = reader.GetInt32(5);


                        AllAlternateList.Add(newAltermatePokemon);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }

            return AllAlternateList;
        }

        //Gets all alternates
        public List<Pokemon> SelectAllAlternates()
        {
            List<Pokemon> EntirePokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_all_alternate_forms", dexConn);
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon entirePokemon = new Pokemon();
                        entirePokemon.PokemonNumber = reader.GetInt32(0);
                        entirePokemon.PokemonName = reader.GetString(1);
                        entirePokemon.PokemonType = reader.GetString(2);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            entirePokemon.PokemonType2 = "";
                        }
                        else
                        {
                            entirePokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        entirePokemon.PokemonRegion = reader.GetString(4);
                        entirePokemon.AlternatePokemonNumber = reader.GetInt32(5);

                        EntirePokemonList.Add(entirePokemon);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }

            return EntirePokemonList;
        }

        //Gets all megas
        public List<Pokemon> SelectAllMega()
        {
            List<Pokemon> MegaPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_mega_versions", dexConn);

            try
            {
                dexConn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newMegaPokemon = new Pokemon();
                        newMegaPokemon.PokemonNumber = reader.GetInt32(0);
                        newMegaPokemon.PokemonName = reader.GetString(1);
                        newMegaPokemon.PokemonType = reader.GetString(2);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            newMegaPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newMegaPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        newMegaPokemon.PokemonRegion = reader.GetString(4);
                        newMegaPokemon.AlternatePokemonNumber = reader.GetInt32(5);

                        MegaPokemonList.Add(newMegaPokemon);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }

            return MegaPokemonList;
        }

        //Gets a list of all pokemon
        public List<Pokemon> SelectAllPokemon()
        {
            List<Pokemon> PokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_fill_dex", dexConn);
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        PokemonList.Add(newPokemon);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }

            return PokemonList;
        }

        //Selects all regional variants
        public List<Pokemon> SelectAllRegionals()
        {
            List<Pokemon> PokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_regional_versions", dexConn);
            try
            {
                dexConn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        newPokemon.AlternatePokemonNumber = reader.GetInt32(5);
                        PokemonList.Add(newPokemon);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return PokemonList;
        }

        //Selects all shinys
        public List<Pokemon> SelectAllShinies()
        {
            List<Pokemon> ShinyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_shiny_versions", dexConn);
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newShinyPokemon = new Pokemon();
                        newShinyPokemon.PokemonNumber = reader.GetInt32(0);
                        newShinyPokemon.PokemonName = reader.GetString(1);
                        newShinyPokemon.PokemonType = reader.GetString(2);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            newShinyPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newShinyPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        newShinyPokemon.PokemonRegion = reader.GetString(4);
                        newShinyPokemon.AlternatePokemonNumber = reader.GetInt32(5);

                        ShinyPokemonList.Add(newShinyPokemon);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return ShinyPokemonList;
        }

        //Select alternate pokemon stats for dex entry
        public PokedexEntry SelectAlternateStats(string AlternateName)
        {
            PokedexEntry alternatePokemon = new PokedexEntry();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_alternate_pokemon_stats", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AlternatePokemonName", SqlDbType.NVarChar);
            cmd.Parameters["@AlternatePokemonName"].Value = AlternateName;

            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    alternatePokemon.PokemonNames = reader.GetString(0);
                    alternatePokemon.PokemonTypes = reader.GetString(1);
                    if (reader["AlternatePokemonType2"] == DBNull.Value)
                    {
                        alternatePokemon.PokemonTypes2 = "";
                    }
                    else
                    {
                        alternatePokemon.PokemonTypes2 = Convert.ToString(reader["AlternatePokemonType2"]);
                    }
                    alternatePokemon.PokemonHP = reader.GetInt32(3);
                    alternatePokemon.PokemonAttack = reader.GetInt32(4);
                    alternatePokemon.PokemonDefense = reader.GetInt32(5);
                    alternatePokemon.PokemonSpecialAttack = reader.GetInt32(6);
                    alternatePokemon.PokemonSpecialDefense = reader.GetInt32(7);
                    alternatePokemon.PokemonSpeed = reader.GetInt32(8);
                    alternatePokemon.PokemonHeight = reader.GetString(9);
                    alternatePokemon.PokemonWeight = reader.GetString(10);
                    alternatePokemon.PokemonGender = reader.GetString(11);
                    alternatePokemon.PokemonCategory = reader.GetString(12);
                    if (reader["AbilityName"] == DBNull.Value)
                    {
                        alternatePokemon.PokemonAbility = "";
                    }
                    else
                    {
                        alternatePokemon.PokemonAbility = Convert.ToString(reader["AbilityName"]);
                    }
                    if (reader["AlternateAbility2"] == DBNull.Value)
                    {
                        alternatePokemon.PokemonAbility2 = "";
                    }
                    else
                    {
                        alternatePokemon.PokemonAbility2 = Convert.ToString(reader["AlternateAbility2"]);
                    }
                    alternatePokemon.DexEntry = reader.GetString(15);
                    alternatePokemon.PokemonImage = reader.GetString(16);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();

            }
            return alternatePokemon;
        }

        //Method to fill the combo box on the pokedex page
        public List<Pokemon> SelectAlternateVersions(int PokemonNumber)
        {
            List<Pokemon> AlernateVersions = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_fill_cboAlternates", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon alteratePokemon = new Pokemon();
                        alteratePokemon.PokemonName = reader.GetString(0);
                        // This one actually gets the alternate pokemon number so I can use it
                        // to get the rest of the data
                        alteratePokemon.PokemonNumber = reader.GetInt32(1);
                        AlernateVersions.Add(alteratePokemon);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return AlernateVersions;
        }

        //Selects alternates for specific user
        public List<Pokemon> SelectMyAlternatePokemon(int UserID)
        {
            List<Pokemon> MyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_my_alternate_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon myPokemon = new Pokemon();
                        myPokemon.PokemonNumber = reader.GetInt32(1);
                        myPokemon.PokemonName = reader.GetString(2);
                        myPokemon.PokemonType = reader.GetString(3);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            myPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            myPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        myPokemon.PokemonRegion = reader.GetString(5);
                        myPokemon.AlternatePokemonNumber = reader.GetInt32(6);

                        MyPokemonList.Add(myPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return MyPokemonList;
        }

        //Selects all megas for specific user
        public List<Pokemon> SelectMyMegaPokemon(int UserID)
        {
            List<Pokemon> MyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_my_mega_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;

            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon myPokemon = new Pokemon();
                        myPokemon.PokemonNumber = reader.GetInt32(1);
                        myPokemon.PokemonName = reader.GetString(2);
                        myPokemon.PokemonType = reader.GetString(3);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            myPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            myPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        myPokemon.PokemonRegion = reader.GetString(5);
                        myPokemon.AlternatePokemonNumber = reader.GetInt32(6);
                        MyPokemonList.Add(myPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return MyPokemonList;
        }

        //Selects all of single users pokemon
        public List<Pokemon> SelectMyPokemon(int UserID)
        {
            List<Pokemon> MyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_my_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;

            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon myPokemon = new Pokemon();
                        myPokemon.PokemonNumber = reader.GetInt32(1);
                        myPokemon.PokemonName = reader.GetString(2);
                        myPokemon.PokemonType = reader.GetString(3);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            myPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            myPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        myPokemon.PokemonRegion = reader.GetString(5);

                        MyPokemonList.Add(myPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return MyPokemonList;
        }

        //Select regional pokemon for specific user
        public List<Pokemon> SelectMyRegionalPokemon(int UserID)
        {
            List<Pokemon> MyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_my_regional_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;

            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon myPokemon = new Pokemon();
                        myPokemon.PokemonNumber = reader.GetInt32(1);
                        myPokemon.PokemonName = reader.GetString(2);
                        myPokemon.PokemonType = reader.GetString(3);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            myPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            myPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        myPokemon.PokemonRegion = reader.GetString(5);
                        myPokemon.AlternatePokemonNumber = reader.GetInt32(6);

                        MyPokemonList.Add(myPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return MyPokemonList;
        }

        //Selects users shiny pokemon
        public List<Pokemon> SelectMyShinyPokemon(int UserID)
        {
            List<Pokemon> MyPokemonList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_my_shiny_pokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon myPokemon = new Pokemon();
                        myPokemon.PokemonNumber = reader.GetInt32(1);
                        myPokemon.PokemonName = reader.GetString(2);
                        myPokemon.PokemonType = reader.GetString(3);
                        if (reader["AlternatePokemonType2"] == DBNull.Value)
                        {
                            myPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            myPokemon.PokemonType2 = Convert.ToString(reader["AlternatePokemonType2"]);
                        }
                        myPokemon.PokemonRegion = reader.GetString(5);
                        myPokemon.AlternatePokemonNumber = reader.GetInt32(6);
                        MyPokemonList.Add(myPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return MyPokemonList;
        }

        public List<Pokemon> SelectPokemonByRegion(string Region)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_region", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Region", SqlDbType.NVarChar);
            cmd.Parameters["@Region"].Value = Region;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects pokemon by region and type
        public List<Pokemon> SelectPokemonByRegionAndType(string Region, string type)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_region_and_type", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Region", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PokemonType", SqlDbType.NVarChar);
            cmd.Parameters["@Region"].Value = Region;
            cmd.Parameters["@PokemonType"].Value = type;

            try
            {
                dexConn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects pokemon by region and type 2
        public List<Pokemon> SelectPokemonByRegionAndType2(string Region, string type2)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_region_and_type2", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Region", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PokemonType2", SqlDbType.NVarChar);
            cmd.Parameters["@Region"].Value = Region;
            cmd.Parameters["@PokemonType2"].Value = type2;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects all pokemon by type
        public List<Pokemon> SelectPokemonByType(string Type)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_type", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonType", SqlDbType.NVarChar);
            cmd.Parameters["@PokemonType"].Value = Type;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects all pokemon by type 2
        public List<Pokemon> SelectPokemonByType2(string Type2)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_type2", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonType2", SqlDbType.NVarChar);
            cmd.Parameters["@PokemonType2"].Value = Type2;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects all pokemon by type and type 2
        public List<Pokemon> SelectPokemonByTypeAndType2(string Type, string Type2)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_type_and_type2", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonType", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PokemonType2", SqlDbType.NVarChar);
            cmd.Parameters["@PokemonType"].Value = Type;
            cmd.Parameters["@PokemonType2"].Value = Type2;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Selects all by Type, type 2, and region
        public List<Pokemon> SelectPokemonByTypeType2AndRegion(string Region, string Type, string Type2)
        {
            List<Pokemon> FilteredList = new List<Pokemon>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_filter_dex_by_region_type_and_type2", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Region", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PokemonType", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PokemonType2", SqlDbType.NVarChar);
            cmd.Parameters["@Region"].Value = Region;
            cmd.Parameters["@PokemonType"].Value = Type;
            cmd.Parameters["@PokemonType2"].Value = Type2;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pokemon newPokemon = new Pokemon();
                        newPokemon.PokemonNumber = reader.GetInt32(0);
                        newPokemon.PokemonName = reader.GetString(1);
                        newPokemon.PokemonType = reader.GetString(2);
                        if (reader["PokemonType2"] == DBNull.Value)
                        {
                            newPokemon.PokemonType2 = "";
                        }
                        else
                        {
                            newPokemon.PokemonType2 = Convert.ToString(reader["PokemonType2"]);
                        }
                        newPokemon.PokemonRegion = reader.GetString(4);
                        FilteredList.Add(newPokemon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return FilteredList;
        }

        //Stores alternate pokemon for user
        public void StoreAlternatePokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_pokemon_into_myalternatepokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Stores mega pokemon for user
        public void StoreMegaPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_pokemon_into_mymegapokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Stores normal pokemon
        public void StorePokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_pokemon_into_mypokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Stores regional pokemon for user
        public void StoreRegionalPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_pokemon_into_myregionalpokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
        }

        //Stores shiny pokemon for user
        public void StoreShinyPokemon(int PokemonNumber, int UserID)
        {
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_pokemon_into_myshinypokemon", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PokemonNumber", SqlDbType.Int);
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@PokemonNumber"].Value = PokemonNumber;
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();

            }
        }
    }
}
