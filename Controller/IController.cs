using System.Collections.Generic;
using Models;

namespace Controllers
{
    public interface IController
    {
        IReadOnlyCollection<UserInfo> GetUsers();
        IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname);
        UserInfo GetUserByPhone(string phone);
        bool AddUser(string name, string surname, string phone);
        bool EditUser(UserInfo user, string name, string surname, string phone);
        bool DeleteUser(string name, string surname);
        bool LoadDB();
        bool SaveDB();
    }
}
