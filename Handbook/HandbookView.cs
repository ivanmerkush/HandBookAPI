using System;
using System.Collections.Generic;
using Models;
using Controllers;

namespace Views
{
    /// <summary>
    /// Containts standart methods to work with list of users
    /// </summary>
    public abstract class HandbookView
    {
        private readonly BookController Controller;

        protected HandbookView()
        {
            Controller = new BookController();
        }
        protected IReadOnlyCollection<UserInfo> GetUsers() => Controller.GetUsers();

        protected UserInfo GetUserByNameAndSurname(string name, string surname) => Controller.GetUser(name, surname);

        protected bool AddUser(string name, string surname, string phone) => Controller.AddUser(name, surname, phone);

        protected bool EditUser(string name, string surname, string newValue, Parameter parameter) => Controller.EditUser(name, surname, newValue, parameter);

        protected bool DeleteUser(string name, string surname) => Controller.DeleteUser(name, surname);

        protected void LoadDB() => Controller.LoadDB();

        protected void SaveDB() => Controller.SaveDB();

        public void ChangeHandler(object source, EventArgs eventArgs)
        {
            Print("UserList was changed.");
            Users copy = source as Users;
            if (copy != null)
            {
                foreach (UserInfo user in copy.GetUsers())
                {
                    PrintUser(user);
                }
            }
        }

        /// <summary>
        /// Reads text from some source
        /// </summary>
        /// <returns></returns>
        public abstract string Read();

        /// <summary>
        /// Prints user
        /// </summary>
        /// <param name="userInfo"></param>
        public abstract void PrintUser(UserInfo userInfo);

        /// <summary>
        /// Prints text 
        /// </summary>
        /// <param name="text"></param>
        public abstract void Print(string text);
    }
}
