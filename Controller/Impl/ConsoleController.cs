using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;

namespace Controllers
{
    class ConsoleController : IController
    {
        public IModel Model { get; }
        public IUserView View { get; }

        internal ConsoleController(IUserView view, IModel model)
        {
            Model = model;
            View = view;
        }

        public void AddUser(UserInfo user)
        {
            if (Model.Exists(user.Phone))
            {
                View.AppendNotifierText("This user already exists");
            }
            else
            {
                Model.Add(user);
                View.AppendNotifierText("New user was added");
            }
        }

        public void DeleteUser(UserInfo userInfo)
        {
            try
            {
                if (Model.Exists(userInfo.Name, userInfo.Surname))
                {
                    Model.Delete(userInfo.Name, userInfo.Surname);
                    View.AppendNotifierText("User was deleted.");
                    View.DisableEdittingUsers();
                }
                else
                {
                    View.AppendNotifierText("This user doesn't exist.");
                }
            }
            catch(ArgumentNullException)
            {
                View.ShowMessageBox("User is null");
            }
            
        }

        public void EditUser(UserInfo editedUser)
        {
            if (Model.Exists(editedUser.Name, editedUser.Surname, editedUser.Phone))
            {
                View.AppendNotifierText("Not unique attributes");
            }
            else
            {
                View.AppendNotifierText("User was edited.");
                Model.Edit(editedUser);
                View.DisableEdittingUsers();
            }
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            IReadOnlyCollection<UserInfo> users = Model.GetUser(name, surname);
            if(users.Count == 0)
            {
                View.AppendNotifierText("Doesn't exist");
            }
            return users;
        }

        public UserInfo GetUserByPhone(string phone)
        {
            UserInfo userInfo = Model.GetUser(phone);
            if (userInfo == null)
            {
                View.AppendNotifierText("Not found");
            }
            return userInfo;
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            View.AppendNotifierText("All users:");
            return Model.GetAll();
        }

        public void LoadDB()
        {
            if (Model.TryLoad())
            {
                View.AppendNotifierText("Users were successfully loaded from file.");
                View.DisableEdittingUsers();
            }
            else
            {
                View.AppendNotifierText("Problem happened during loading users");
            }
        }

        public void SaveDB()
        {
            if (Model.TrySave())
            {
                View.AppendNotifierText("Users were successfully saved to file.");
            }
            else
            {
                View.AppendNotifierText("Problem happened during saving users");
            }
        }
    }
}
