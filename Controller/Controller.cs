using Models;
using System.Collections.Generic;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    public class BookController
    {
        public List<UserInfo> GetUsers(Users users) => users.GetUsers();

        public UserInfo GetUser(Users users, string name, string surname) => users.GetUser(name, surname);

        /// <summary>
        /// Adds new user with values of name surname and phone
        /// </summary>
        /// <param name="users"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool AddUser(Users users, string name, string surname, string phone)
        {
            if (users.Exists(name, surname) || users.Exists(phone))
            {
                return false;
            }
            users.AddUserInfo(name, surname, phone);
            return true;
        }

        public bool EditUser(Users users, string name, string surname, string newValue, Parameter parameter)
        {
            UserInfo user = users.GetUser(name, surname);
            if (user != null)
            {
                user.ChangeValue(newValue, parameter);
                return true;
            }
            return false;
        }

        public bool DeleteUser(Users users, string name, string surname)
        {
            if (users.Exists(name, surname))
            {
                users.DeleteUser(name, surname);
                return true;
            }
            return false;
        }
        public void LoadDB(Users users) => users.LoadUsers();

        public void SaveDB(Users users) => users.SaveUsers();
    }
}
