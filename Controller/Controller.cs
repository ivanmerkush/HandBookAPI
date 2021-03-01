using Models;
using System.Collections.Generic;
using System;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    public class BookController
    {
        public event EventHandler<ActionEventArgs> ControllerEvent;

        private readonly Users users;

        public BookController()
        {
            users = new Users();
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.GetAll, null));
            return users.GetUsers();
        }

        public bool Exists(string name, string surname)
        {
            if(users.Exists(name, surname))
            {
                return true;
            }
            else
            {
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Check, null));
                return false;
            }
        }

        public UserInfo GetUser(string name, string surname)
        {
            UserInfo user = null;
            if (Exists(name, surname))
            {
                user = users.GetUser(name, surname);
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Get, user));
            }
            return user;
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
            if (!Exists(name, surname))
            {
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Add, users.AddUserInfo(name, surname, phone)));
            }
        }

        public void EditUser(string name, string surname, string newValue, Parameters parameter)
        {
            if (Exists(name, surname))
            {
                UserInfo user = users.GetUser(name, surname);
                users.EditInfo(user, newValue, parameter);
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Edit, user));
            }
        }

        public void DeleteUser(string name, string surname)
        {
            if (Exists(name, surname))
            {
                users.DeleteUser(name, surname);
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Delete, null));
            }
        }
        public void LoadDB()
        {
            users.LoadUsers();
            ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Load, null));
        }

        public void SaveDB()
        {
            users.SaveUsers();
            ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Load, null));
        }
    }
}
