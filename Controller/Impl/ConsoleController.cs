using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary;

namespace Controllers
{
    class ConsoleController : IController
    {

        private readonly IModel model;
        private readonly IUserView view;

        internal ConsoleController(IUserView view)
        {
            model = new Users();
            this.view = view;
        }

        public void AddUser(string name, string surname, string phone)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public void EditUser(UserInfo user, string name, string surname, string phone)
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
