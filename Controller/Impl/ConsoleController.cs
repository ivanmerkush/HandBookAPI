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

        internal ConsoleController(IUserView view)
        {
            Model = Users.Instance;
            View = view;
        }

        public void AddUser(UserInfo user)
        {
            if (Model.Exists(user.Phone))
            {
                View.NotifierText = "This user already exists";
            }
            else
            {
                Model.Add(user);
                View.NotifierText = "New user was added";
            }
        }

        public void DeleteUser(UserInfo userInfo)
        {
            try
            {
                if (Model.Exists(userInfo.Name, userInfo.Surname))
                {
                    Model.Delete(userInfo.Name, userInfo.Surname);
                    View.NotifierText = "User was deleted.";
                    View.EditingVisible = false;
                }
                else
                {
                    View.NotifierText = "This user doesn't exist.";
                }
            }
            catch(ArgumentNullException)
            {
                View.MessageBoxText = "User is null";
            }
            
        }

        public void EditUser(UserInfo editedUser)
        {
            if (Model.Exists(editedUser.Name, editedUser.Surname, editedUser.Phone))
            {
                View.NotifierText= "Not unique attributes";
            }
            else
            {
                View.NotifierText = "User was edited.";
                Model.Edit(editedUser);
                View.EditingVisible = false;
            }
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            IReadOnlyCollection<UserInfo> users = Model.GetUser(name, surname);
            if(users.Count == 0)
            {
                View.NotifierText = "Doesn't exist";
            }
            return users;
        }

        public UserInfo GetUserByPhone(string phone)
        {
            UserInfo userInfo = Model.GetUser(phone);
            if (userInfo == null)
            {
                View.NotifierText = "Not found";
            }
            return userInfo;
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            View.NotifierText = "All users:";
            return Model.GetAll();
        }

        public void LoadDB()
        {
            if (Model.TryLoad())
            {
                View.NotifierText = "Users were successfully loaded from file.";
                View.EditingVisible = false;
            }
            else
            {
                View.NotifierText = "Problem happened during loading users";
            }
        }

        public void SaveDB()
        {
            if (Model.TrySave())
            {
                View.NotifierText = "Users were successfully saved to file.";
            }
            else
            {
                View.NotifierText = "Problem happened during saving users";
            }
        }
    }
}
