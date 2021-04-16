using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary;

namespace Controllers
{
    class ConsoleController : IController
    {

        public IModel Model { get; }
        public IUserView View { get; }

        internal ConsoleController(IUserView view)
        {
            Model = new Users();
            View = view;
        }

        public void AddUser(UserInfo user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public void EditUser(UserInfo oldUser, UserInfo newUser)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetUserByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void LoadDB()
        {
            throw new NotImplementedException();
        }

        public void SaveDB()
        {
            throw new NotImplementedException();
        }
    }
}
