using System;
using System.Collections.Generic;
using Models;
using ControllerAndViewAbstraction;

namespace Controllers
{
    public class ConsoleController : IController
    {

        private readonly IModel model;
        private readonly IUserView view;

        public ConsoleController(IUserView view)
        {
            model = new Users();
            this.view = view;
        }

        public bool AddUser(string name, string surname, string phone)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(UserInfo user, string name, string surname, string phone)
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
