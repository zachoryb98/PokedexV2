using PokedexDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexLogicLayer
{
    public interface IPokedexUserManager
    {
        PokedexUser AuthenticatePokedexUser(string email, string password);

        bool UpdatePassword(int userID, string newPassword, string oldPassword);

        int GetUserID(string email);

        List<PokedexUser> RetrieveUserListByActive(bool active = true);

        bool EditUser(PokedexUser oldUser, PokedexUser newUser);

        bool AddUser(PokedexUser user);

        bool setActiveUserState(bool active, int UserID);

        List<string> RetrieveUserRoles(int UserID);
        List<string> RetrieveUserRoles();

        bool DeleteUserRole(int UserID, string Role);
        bool AddUserRole(int UserID, string Role);

    }
}
