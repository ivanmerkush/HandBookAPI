using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;

namespace Controllers.Impl
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    class MainFormController : IController
    {
        public IModel Model { get; }
        public IUserView View { get; }

        internal MainFormController(IUserView view, IModel model)
        {
            Model = model;
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
                View.ShowMessageBox("This user already exists");
            }
            else
            {
                Model.Add(user);
                View.AppendNotifierText(">New user was added");
            }
        }

        public void EditUser(UserInfo editedUser)
        {
            if (editedUser == null)
            {
                View.ShowMessageBox("Somehow you clicked this button without selecting user, I wont let you pass.");
            } 
            else
            {
                if (Model.Exists(editedUser.Name, editedUser.Surname, editedUser.Phone))
                {
                    View.ShowMessageBox("Not unique attributes");
                }
                else
                {
                    View.AppendNotifierText(">User was edited.");
                    Model.Edit(editedUser);
                    View.DisableEdittingUsers();
                }
            }
        }

        public void DeleteUser(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                View.ShowMessageBox("Somehow you clicked this button without selecting user, I wont let you pass.");
            }
            else
            {
                if (Model.Exists(userInfo.Name, userInfo.Surname))
                {
                    Model.Delete(userInfo.Name, userInfo.Surname);
                    View.AppendNotifierText(">User was deleted.");
                    View.DisableEdittingUsers();
                }
                else
                {
                    View.ShowMessageBox("Problem occuried during delete.");
                }
            }
        }
        
        public void LoadDB()
        {
            if(Model.TryLoad())
            {
                View.AppendNotifierText(">Users were successfully loaded from file.");
                View.DisableEdittingUsers();
            }
            else
            {
                View.ShowMessageBox("Problem happened during loading users");
            }
        }

        public void SaveDB()
        {
            if(Model.TrySave())
            {
                View.AppendNotifierText(">Users were successfully saved to file.");
            }
            else
            {
                View.ShowMessageBox("Problem happened during saving users");
            }
        }
    }
}
