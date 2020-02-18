using PokedexDataObjects;
using System.Collections.Generic;

namespace PokedexAccessLayer
{
    public interface IUserAccessor
    {
        PokedexUser AuthenticatePokedexUser(string username, string passwordHash);

        bool UpdatePasswordHash(int userID, string oldPasswordHash, string newPasswordHash);

        int GetUserID(string email);


        List<PokedexUser> SelectUsersByActive(bool active = true);

        int UpdateUser(PokedexUser oldUser, PokedexUser newUser);

        int InsertUser(PokedexUser user);

        int ActivateUser(int userID);

        int DeactivateUser(int userID);

        List<string> SelectAllRoles();

        List<string> SelectRollsByUserID(int UserID);

        int InsertOrDeleteUserRole(int UserID, string role, bool delete = false);

    }
}
