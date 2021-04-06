using System.Collections.Generic;
using Models;

namespace ControllerAndViewAbstraction
{
    public interface IController
    {
        IReadOnlyCollection<UserInfo> GetUsers();
        IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname);
        UserInfo GetUserByPhone(string phone);
        bool AddUser(string name, string surname, string phone);
        bool EditUser(UserInfo user, string name, string surname, string phone);
        bool DeleteUser(string name, string surname);
        void LoadDB();
        void SaveDB();
    }
}
