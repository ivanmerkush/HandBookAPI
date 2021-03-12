using System.Collections.Generic;
using Models;

namespace Controllers
{
    public interface IController
    {
        IReadOnlyCollection<UserInfo> GetUsers();
        UserInfo GetUser(string name, string surname);
        bool AddUser(string name, string surname, string phone);
        bool EditUser(UserInfo user, string name, string surname, string phone);
        bool DeleteUser(string name, string surname);
        bool LoadDB();
        bool SaveDB();
    }
}
