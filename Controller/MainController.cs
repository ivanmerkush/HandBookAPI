using Models;
using System.Collections.Generic;
using System;
using Views;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    public class MainController : IController
    {
        private readonly IModel model;
        private readonly IUserView view;

        public MainController(IUserView view)
        {
            model = new Users();
            this.view = view;
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            return model.GetAll();
        }


        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            return model.GetUser(name, surname);
        }

        public UserInfo GetUserByPhone(string phone)
        {
            return model.GetUser(phone);
        }

        

        /// <summary>
        /// Adds new user with values of name surname and phone
        /// </summary>
        /// <param name="users"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool AddUser(string name, string surname, string phone)
        {
            if (model.Exists(phone))
            {
                return false;
            }
            model.Add(name, surname, phone);
            return true;
        }

        public bool EditUser(UserInfo user, string name, string surname, string phone)
        {
            if (model.Exists(name, surname, phone))
            {
                return false;
            }
            model.Edit(user, new UserInfo(name, surname, phone));
            return true;
        }

        public bool DeleteUser(string name, string surname)
        {
            if (model.Exists(name, surname))
            {
                model.Delete(name, surname);
                return true;
            }
            return false;
        }

        public bool LoadDB()
        {
            if (model is Users users)
            {
                return users.TryLoad();
            }
            return false;
        }

        public bool SaveDB()
        {
            if (model is Users users)
            {
                return users.TrySave();
            }
            return false;
        }
    }
}
