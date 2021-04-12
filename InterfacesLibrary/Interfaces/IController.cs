using System.Collections.Generic;
using Models;

namespace InterfacesLibrary
{
    public interface IController
    {
        IReadOnlyCollection<UserInfo> GetUsers();
        IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname);
        UserInfo GetUserByPhone(string phone);
        void AddUser(string name, string surname, string phone);
        void EditUser(UserInfo user, string name, string surname, string phone);
        void DeleteUser(UserInfo userInfo);
        void LoadDB();
        void SaveDB();
    }
}
