using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    /// <summary>
    /// Containts list of user's info and implements methods to work with it
    /// </summary>
    public class Users
    {
        public event EventHandler<UserEventArgs> Changed;

        private List<UserInfo> userList;

        public Users()
        {
            userList = new List<UserInfo>();
        }

        /// <summary>
        /// Gets copy of user's list
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            return userList;
        }

        /// <summary>
        /// Finds user with proper name and surname
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public UserInfo GetUser(string name, string surname)
        {
            return userList.Find(user => user.Name.Equals(name) && user.Surname.Equals(surname));
        }

        /// <summary>
        /// Checks if this user exists in list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public bool Exists(string name, string surname)
        {
            return userList.Exists(user => user.Name.Equals(name) &&
                                           user.Surname.Equals(surname));
        }

        /// <summary>
        /// Checks if user with this phone exists
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Exists(string phone) => userList.Exists(user => user.Phone.Equals(phone));

        /// <summary>
        /// Edits information about some user
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="newValue"></param>
        /// <param name="parameter"></param>
        public void EditInfo(UserInfo userInfo, string newValue, Parameter parameter)
        {
            
            UserInfo edited = userInfo.ChangeValue(newValue, parameter);
            Changed(this, new UserEventArgs(edited, "User was edited."));
        }

        /// <summary>
        /// Adds user to the list, if there are no duplicates
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        public void AddUserInfo(string name, string surname, string phone)
        {
            UserInfo userInfo = new UserInfo(name, surname, phone);
            userList.Add(userInfo);
            Changed(this, new UserEventArgs(userInfo, "New user's infromation was added to list."));
        }

        /// <summary>
        /// Deletes user, if it exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public void DeleteUser(string name, string surname)
        {
            userList.RemoveAll(user => user.Name.Equals(name) && user.Surname.Equals(surname));
        }

        /// <summary>
        /// Loads Users from file
        /// </summary>
        public void LoadUsers()
        {
            try
            {
                userList.Clear();
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.txt");
                string text = File.ReadAllText(path);
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] parameters = lines[i].Split(' ');
                    userList.Add(new UserInfo(parameters[0], parameters[1], parameters[2]));
                }
            }
            catch (IOException)
            {

            }

        }

        /// <summary>
        /// Saves users to file
        /// </summary>
        public void SaveUsers()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (UserInfo userInfo in userList)
                {
                    stringBuilder.Append(userInfo.ToString()).Append("\n");
                }
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.txt");
                File.WriteAllText(path, stringBuilder.ToString());
            }
            catch (IOException)
            {

            }

        }
    }

    public enum Parameter
    {
        Name, Surname, Phone
    };
}
