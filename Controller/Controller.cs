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

        public UserInfo GetUser(string name, string surname)
        {
            UserInfo user = users.GetUser(name, surname);
            if (user != null)
            {
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
        public bool AddUser(string name, string surname, string phone)
        {
            if (users.Exists(name, surname) || users.Exists(phone))
            {
                return false;
            }
            ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Add, users.AddUserInfo(name, surname, phone)));
            return true;
        }

        public bool EditUser(string name, string surname, string newValue, Parameters parameter)
        {

            UserInfo user = users.GetUser(name, surname);
            if (user != null)
            {
                users.EditInfo(user, newValue, parameter);
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Edit, user));
                return true;
            }
            return false;

        }

        public bool DeleteUser(string name, string surname)
        {
            if (users.Exists(name, surname))
            {
                users.DeleteUser(name, surname);
                ControllerEvent?.Invoke(this, new ActionEventArgs(Actions.Delete, null));
                return true;
            }
            return false;
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
