using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using PokedexAccessLayer;
using PokedexDataObjects;

namespace PokedexLogicLayer
{
    public class PokedexUserManager : IPokedexUserManager
    {
        private IUserAccessor _userAccessor;

        public PokedexUserManager()
        {
            _userAccessor = new UserAccessor();
        }

        public PokedexUserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        public bool AddUser(PokedexUser user)
        {
            bool result = true;
            try
            {
                result = _userAccessor.InsertUser(user) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("User not added", ex);
            }

            return result;
        }

        public bool AddUserRole(int UserID, string Role)
        {
            bool result = false;
            try
            {
                result = 1 == _userAccessor.InsertOrDeleteUserRole(UserID, Role);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not added", ex);
            }
            return result;
        }

        public PokedexUser AuthenticatePokedexUser(string email, string password)
        {
            PokedexUser dexUserResult = null;

            // We need to hash the password
            var passwordHash = hashUserPassword(password);
            password = null;

            try
            {
                dexUserResult = _userAccessor.AuthenticatePokedexUser(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login Failed, Please try again!", ex);
            }

            return dexUserResult;
        }

        public bool DeleteUserRole(int UserID, string Role)
        {
            bool result = false;
            try
            {
                result = 1 == _userAccessor.InsertOrDeleteUserRole(UserID, Role, delete: true);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Role not removed", ex);
            }
            return result;
        }

        public bool EditUser(PokedexUser oldUser, PokedexUser newUser)
        {
            bool result = false;

            try
            {
                result = _userAccessor.UpdateUser(oldUser, newUser) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }

        public int GetUserID(string email)
        {
            int currentUserID = 0;
            try
            {
                currentUserID = _userAccessor.GetUserID(email);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Could not get user data, Please try again!", ex);
            }

            return currentUserID;
            
        }

        public List<PokedexUser> RetrieveUserListByActive(bool active = true)
        {
            try
            {
                return _userAccessor.SelectUsersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        public List<string> RetrieveUserRoles(int UserID)
        {
            List<string> roles = null;
            try
            {
                roles = _userAccessor.SelectRollsByUserID(UserID);
            }

            catch (Exception)
            {

                throw new ApplicationException("Failed to get roles");
            }
            return roles;
        }

        public List<string> RetrieveUserRoles()
        {
            List<string> roles = null;
            try
            {
                roles = _userAccessor.SelectAllRoles();
            }

            catch (Exception)
            {

                throw new ApplicationException("Failed to get roles");
            }
            return roles;
        }
    

        public bool setActiveUserState(bool active, int UserID)
        {
            bool result = false;
            try
            {
                if (active)
                {
                    result = 1 == _userAccessor.ActivateUser(UserID);
                }
                else
                {
                    result = 1 == _userAccessor.DeactivateUser(UserID);
                }
                if (result == false)
                {
                    throw new ApplicationException("Employee record out of date");
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update to user failed", ex);
            }
            return result;
        }

        public bool UpdatePassword(int userID, string newPassword, string oldPassword)
        {
            bool updated = false;

            string newPasswordHash = hashUserPassword(newPassword);
            string oldPasswordHash = hashUserPassword(oldPassword);

            try
            {
                updated = _userAccessor.UpdatePasswordHash(userID,
                    oldPasswordHash, newPasswordHash);
            }catch(Exception ex)
            {
                throw new ApplicationException("Password update failed.", ex);
            }
            return updated;
        }

        private string hashUserPassword(string source)
        {
            string dexUserResult = null;

            // Byte array is necessary for this
            byte[] data;

            //This creates the hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                //Hash the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // build new string from the result
            var s = new StringBuilder();

            // This loops through the bytes to build a string
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            dexUserResult = s.ToString().ToUpper();

            return dexUserResult;
        }
    }
}
