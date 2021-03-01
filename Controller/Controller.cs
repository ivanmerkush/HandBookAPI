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
        public event EventHandler<RequestEventArgs> ControllerEvent;

        private readonly Users users;

        public BookController()
        {
            users = new Users();
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            ControllerEvent?.Invoke(this, new RequestEventArgs("All user's information from list;", null));
            return users.GetUsers();
        }
        public UserInfo GetUser(string name, string surname)
        {
            UserInfo user = users.GetUser(name, surname);
            if (user == null)
            {
                ControllerEvent?.Invoke(this, new RequestEventArgs("This user wasn't found;", null));
            }
            else
            {
                ControllerEvent?.Invoke(this, new RequestEventArgs("Found him", user));
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
            if (users.Exists(name, surname) || users.Exists(phone))
            {
                ControllerEvent?.Invoke(this, new RequestEventArgs("This user already exists", null));
            }
            ControllerEvent?.Invoke(this, new RequestEventArgs("A new user was added", users.AddUserInfo(name, surname, phone)));
        }

        public void EditUser(string name, string surname, string newValue, Parameter parameter)
        {

            UserInfo user = users.GetUser(name, surname);
            if (user != null)
            {
                users.EditInfo(user, newValue, parameter);
                ControllerEvent?.Invoke(this, new RequestEventArgs("User was edited", user));
            }
            ControllerEvent?.Invoke(this, new RequestEventArgs("This user doesn't exist", null));
        }

        public void DeleteUser(string name, string surname)
        {
            if (users.Exists(name, surname))
            {
                users.DeleteUser(name, surname);
                ControllerEvent?.Invoke(this, new RequestEventArgs("Removed succesfully", null));
            }
            ControllerEvent?.Invoke(this, new RequestEventArgs("This user doesn't exist", null));
        }
        public void LoadDB()
        {
            users.LoadUsers();
            ControllerEvent?.Invoke(this, new RequestEventArgs("User's list was loaded from file", null));
        }

        public void SaveDB()
        {
            users.SaveUsers();
            ControllerEvent?.Invoke(this, new RequestEventArgs("User's lsit saved to file", null));
        }
    }
}
