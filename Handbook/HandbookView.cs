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
        private readonly Users users;
        private readonly BookController Controller;

        protected HandbookView()
        {
            users = new Users();
            Controller = new BookController();
        }
        protected List<UserInfo> GetUsers() => Controller.GetUsers(users);

        protected UserInfo GetUserByName(string name) => Controller.GetUser(users, name, Parameter.Name);

        protected UserInfo GetUserBySurname(string surname) => Controller.GetUser(users, surname, Parameter.Surname);
        
        protected bool AddUser(string name, string surname, string phone) => Controller.AddUser(users, name, surname, phone);

        protected bool EditUser(string oldValue, string newValue, Parameter parameter) => Controller.EditUser(users, oldValue, newValue, parameter);

        protected bool DeleteUser(string name, string surname) => Controller.DeleteUser(users, name, surname);

        protected void LoadDB() => Controller.LoadDB(users);

        protected void SaveDB() => Controller.SaveDB(users);

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
