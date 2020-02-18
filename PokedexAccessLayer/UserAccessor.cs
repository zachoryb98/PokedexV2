using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace PokedexAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public int ActivateUser(int userID)
        {
            int rows = 0;
            var conn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_reactivate_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public PokedexUser AuthenticatePokedexUser(string email, string passwordHash)
        {
            // This will change to 1 if the user is authenticated already.
            PokedexUser dexUserResult = null;

            // We must get a connection
            var dexConn = PokedexDBConnection.GetConnection();

            // YOU NEED A USER SPROC
            var cmd = new SqlCommand("sp_authenticate_pokedex_user");

            // Part of the command object
            cmd.Connection = dexConn;

            // setting the command type here
            cmd.CommandType = CommandType.StoredProcedure;

            //Add parameters for the procedure
            // CHECK VARIABLE LENGTHS
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            //Set the values for the parameters
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            // now that the command is set up we can execute it
            try
            {
                //Open the connection, make sure you close it.
                dexConn.Open();

                // Execute
                if (1 == Convert.ToInt32(cmd.ExecuteScalar()))
                {
                    // if the command worked correctly, get a user object                    
                    dexUserResult = getUserByEmail(email);
                }
                else
                {
                    // Let the user know that their credentials weren't found
                    throw new ApplicationException("User not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Remembered to close the connection
                dexConn.Close();
            }
            return dexUserResult;
        }

        public int DeactivateUser(int userID)
        {
            int rows = 0;
            var conn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_deactivate_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userID);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public int GetUserID(string email)
        {

            int userID = 0;
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_get_userID_by_email", dexConn);
            // setting the command type here
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 250);
            cmd.Parameters["@email"].Value = email;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userID = reader.GetInt32(0);
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
            return userID;
        }

        public int InsertOrDeleteUserRole(int UserID, string role, bool delete = false)
        {
            int rows = 0;
            string cmdOption = delete ? "sp_delete_user_role" : "sp_insert_user_role";
            var conn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand(cmdOption, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@RoleID", role);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }

        public int InsertUser(PokedexUser user)
        {
            int UserID = 0;
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_insert_user", dexConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", user.PokedexUserName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            try
            {
                dexConn.Open();
                UserID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return UserID;
        }

        public List<string> SelectAllRoles()
        {
            List<string> roles = new List<string>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_all_roles");
            cmd.Connection = dexConn;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = reader.GetString(0);
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles;
        }

        public List<string> SelectRollsByUserID(int UserID)
        {
            List<string> roles = new List<string>();
            var dexConn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_roles_by_userid");
            cmd.Connection = dexConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = UserID;
            try
            {
                dexConn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string role = reader.GetString(0);
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles;
        }

        public List<PokedexUser> SelectUsersByActive(bool active = true)
        {
            List<PokedexUser> users = new List<PokedexUser>();
            var conn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_users_by_active");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Active", SqlDbType.Bit);
            cmd.Parameters["@Active"].Value = active;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new PokedexUser();
                        user.PokedexUserID = reader.GetInt32(0);
                        user.PokedexUserName = reader.GetString(1);
                        user.Email = reader.GetString(2);
                        user.Active = reader.GetBoolean(3);
                        users.Add(user);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return users;
        }


        public bool UpdatePasswordHash(int userID, string oldPasswordHash, string newPasswordHash)
        {
            bool succesfulUpdate = false;
            var dexConn = PokedexDBConnection.GetConnection();
            var dexCmd = new SqlCommand("sp_update_user_password");
            dexCmd.Connection = dexConn;
            dexCmd.CommandType = CommandType.StoredProcedure;
            dexCmd.Parameters.Add("@UserID", SqlDbType.Int);
            dexCmd.Parameters.Add("@OldPasswordHash", SqlDbType.NVarChar, 100);
            dexCmd.Parameters.Add("@NewPasswordHash", SqlDbType.NVarChar, 100);

            dexCmd.Parameters["@UserID"].Value = userID;
            dexCmd.Parameters["@OldPasswordHash"].Value = oldPasswordHash;
            dexCmd.Parameters["@NewPasswordHash"].Value = newPasswordHash;
            try
            {
                dexConn.Open();
                int rows = dexCmd.ExecuteNonQuery();
                succesfulUpdate = (rows == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dexConn.Close();
            }
            return succesfulUpdate;
        }

        public int UpdateUser(PokedexUser oldUser, PokedexUser newUser)
        {
            int rows = 0;
            var conn = PokedexDBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", oldUser.PokedexUserID);

            cmd.Parameters.AddWithValue("@NewUserName", newUser.PokedexUserName);
            cmd.Parameters.AddWithValue("@NewEmail", newUser.Email);

            cmd.Parameters.AddWithValue("@OldUserName", oldUser.PokedexUserName);
            cmd.Parameters.AddWithValue("@OldEmail", oldUser.Email);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }

        private PokedexUser getUserByEmail(string email)
        {
            PokedexUser dexUser = new PokedexUser();
            var dexConn = PokedexDBConnection.GetConnection();

            //Two of our command objects
            var cmd1 = new SqlCommand("sp_select_pokedex_user_by_email");
            var cmd2 = new SqlCommand("sp_select_roles_by_UserID");

            // Getting connection on command objects
            cmd1.Connection = dexConn;
            cmd2.Connection = dexConn;

            // Setting the command type for them
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd2.CommandType = CommandType.StoredProcedure;

            // parameters for connection
            cmd1.Parameters.Add("@Email", SqlDbType.NVarChar, 250);
            cmd1.Parameters["@Email"].Value = email;

            cmd2.Parameters.Add("@UserID", SqlDbType.Int);

            try
            {
                //open connection, Remember to CLOSE it!
                dexConn.Open();

                //execute
                var reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    //UserID
                    dexUser.PokedexUserID = reader1.GetInt32(0);
                    dexUser.PokedexUserName = reader1.GetString(1);
                    dexUser.Email = email;
                }
                else
                {
                    throw new ApplicationException("User not found");
                }
                reader1.Close();
                cmd2.Parameters["@UserID"].Value = dexUser.PokedexUserID;
                List<String> roles = new List<String>();
                var reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    string role = reader2.GetString(0);
                    roles.Add(role);
                }
                dexUser.PokedexRoles = roles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dexUser;
        }
    }
}
