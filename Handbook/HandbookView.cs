using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Controllers;

namespace Views
{
    public abstract class HandbookView
    {
        private readonly Users users;
        private BookController Controller { get; }

        protected HandbookView()
        {
            users = new Users();
            Controller = new BookController();
        }

        protected UserInfo GetUserByName(string name) => Controller.GetUser(users, name, Parameter.Name);

        protected void GetUserBySurname(string surname) => Controller.GetUser(users, surname, Parameter.Surname);
        
        protected void AddUser(string name, string surname, string phone) => Controller.AddUser(users, name, surname, phone);

        protected void EditUser(string oldValue, string newValue, Parameter parameter) => Controller.EditUser(users, oldValue, newValue, parameter);

        protected void DeleteUser(string name, string surname) => Controller.DeleteUser(users, name, surname);

        protected void LoadDB() => Controller.LoadDB(users);

        protected void SaveDB() => Controller.SaveDB(users);

        public abstract string Read();
        public abstract void PrintUser(UserInfo userInfo);
        public abstract void Print(string text);
    }
}
