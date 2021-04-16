using System.Collections.Generic;
using Models;

namespace InterfacesLibrary
{
    public interface IController
    {
        IModel Model { get; }
        IUserView View { get; }

        IReadOnlyCollection<UserInfo> GetUsers();
        IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname);
        UserInfo GetUserByPhone(string phone);
        void AddUser(UserInfo user);
        void EditUser(UserInfo oldUser, UserInfo newUser);
        void DeleteUser(UserInfo userInfo);
        void LoadDB();
        void SaveDB();
    }
}
