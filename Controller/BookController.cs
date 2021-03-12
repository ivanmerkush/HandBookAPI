using Models;
using System.Collections.Generic;
using System;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    public class BookController : IController
    {
        private readonly Users users;

        public BookController()
        {
            users = new Users();
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            return users.GetUsers();
        }


        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            return users.GetUser(name, surname);
        }

        public UserInfo GetUserByPhone(string phone)
        {
            return users.GetUser(phone);
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
            if (users.Exists(phone))
            {
                return false;
            }
            users.AddUserInfo(name, surname, phone);
            return true;
        }

        public bool EditUser(UserInfo user, string name, string surname, string phone)
        {
            if (users.Exists(name, surname, phone))
            {
                return false;
            }
            users.EditInfo(user, name, surname, phone);
            return true;
        }

        public bool DeleteUser(string name, string surname)
        {
            if (users.Exists(name, surname))
            {
                users.DeleteUser(name, surname);
                return true;
            }
            return false;
        }

        public bool LoadDB()
        {
            return users.TryLoad();
        }

        public bool SaveDB()
        {
            return users.TrySave();
        }
    }
}
