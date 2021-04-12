using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    class MainFormController : IController
    {
        private readonly IModel model;
        private readonly IUserView view;   

        internal MainFormController(IUserView view)
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
        public void AddUser(string name, string surname, string phone)
        {
            if (model.Exists(phone))
            {
                view.NotifierText = ">This user already exists";
            }
            else
            {
                model.Add(name, surname, phone);
                view.NotifierText = ">New user was added";
            }
        }

        public void EditUser(UserInfo user, string name, string surname, string phone)
        {
            if (model.Exists(name, surname, phone))
            {
                view.MessageBoxText = ">Not unique attributes";
            }
            else
            {
                model.Edit(user, new UserInfo(name, surname, phone));
            }
        }

        public void DeleteUser(UserInfo userInfo)
        {
            if (model.Exists(userInfo.Name, userInfo.Surname))
            {
                model.Delete(userInfo.Name, userInfo.Surname);
                view.NotifierText = ">User was deleted.";
            }
            else
            {
                view.MessageBoxText = "Problem occuried during delete.";
            }
        }

        public void LoadDB()
        {
            if(model.TryLoad())
            {
                view.NotifierText = ">Users were successfully loaded from file.";
            }
            else
            {
                view.MessageBoxText = "Problem happened during loading users";
            }
        }

        public void SaveDB()
        {
            if(model.TrySave())
            {
                view.NotifierText = ">Users were successfully saved to file.";
            }
            else
            {
                view.MessageBoxText = "Problem happened during saving users";
            }
        }
    }
}
