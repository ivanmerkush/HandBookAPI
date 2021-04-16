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
        public IModel Model { get; }
        public IUserView View { get; }

        internal MainFormController(IUserView view)
        {
            Model = new Users();
            View = view;
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            return Model.GetAll();
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            return Model.GetUser(name, surname);
        }

        public UserInfo GetUserByPhone(string phone)
        {
            return Model.GetUser(phone);
        }        

        /// <summary>
        /// Adds new user with values of name surname and phone
        /// </summary>
        /// <param name="users"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public void AddUser(UserInfo user)
        {
            if (Model.Exists(user.Phone))
            {
                View.NotifierText = ">This user already exists";
            }
            else
            {
                Model.Add(user);
                View.NotifierText = ">New user was added";
            }
        }

        public void EditUser(UserInfo oldUser, UserInfo newUser)
        {
            if (View.SelectedUser == null)
            {
                View.MessageBoxText = "Somehow you clicked this button without selecting user, I wont let you pass.";
            } 
            else
            {
                if (Model.Exists(newUser.Name, newUser.Surname, newUser.Phone))
                {
                    View.MessageBoxText = "Not unique attributes";
                }
                else
                {
                    Model.Edit(oldUser, newUser);
                    View.EditingVisible = false;
                }
            }
        }

        public void DeleteUser(UserInfo userInfo)
        {

            if (View.SelectedUser == null)
            {
                View.MessageBoxText = "Somehow you clicked this button without selecting user, I wont let you pass.";
            }
            else
            {
                if (Model.Exists(userInfo.Name, userInfo.Surname))
                {
                    Model.Delete(userInfo.Name, userInfo.Surname);
                    View.NotifierText = ">User was deleted.";
                    View.EditingVisible = false;
                }
                else
                {
                    View.MessageBoxText = "Problem occuried during delete.";
                }
            }
        }

        public void LoadDB()
        {
            if(Model.TryLoad())
            {
                View.NotifierText = ">Users were successfully loaded from file.";
                View.EditingVisible = false;
            }
            else
            {
                View.MessageBoxText = "Problem happened during loading users";
            }
        }

        public void SaveDB()
        {
            if(Model.TrySave())
            {
                View.NotifierText = ">Users were successfully saved to file.";
            }
            else
            {
                View.MessageBoxText = "Problem happened during saving users";
            }
        }
    }
}
