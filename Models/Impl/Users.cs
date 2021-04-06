using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Models
{
    /// <summary>
    /// Containts list of user's info and implements methods to work with it
    /// </summary>
    public class Users : IModel
    {
        private readonly List<UserInfo> userList;

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
        public IReadOnlyCollection<UserInfo> GetAll()
        {
            return userList;
        }

        /// <summary>
        /// Finds user with proper name and surname
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IReadOnlyCollection<UserInfo> GetUser(string name, string surname) => userList.FindAll(user => user.Name == name && user.Surname == surname);

        public UserInfo GetUser(string phone) => userList.Find(user => user.Phone == phone);

        /// <summary>
        /// Checks if user with this phone exists
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Exists(string phone) => userList.Exists(user => user.Phone == phone);

        /// <summary>
        /// Checks if this user exists in list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public bool Exists(string name, string surname)
        {
            return userList.Exists(user => user.Name == name &&
                                           user.Surname == surname);
        }

        public bool Exists(string name, string surname, string phone)
        {
            return userList.Exists(user => user.Name == name &&
                                           user.Surname == surname &&
                                           user.Phone == phone);
        }

        /// <summary>
        /// Edits information about some user
        /// </summary>
        /// <param name="oldUser"></param>
        /// <param name="newValue"></param>
        /// <param name="parameter"></param>
        public void Edit(UserInfo oldUser, UserInfo newUser)
        {
            int index = userList.FindIndex(user => user.Equals(oldUser) && user.Phone == oldUser.Phone); 
            userList[index] = newUser;
        }

        /// <summary>
        /// Adds user to the list, if there are no duplicates
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        public UserInfo Add(string name, string surname, string phone)
        {
            UserInfo userInfo = new UserInfo(name, surname, phone);
            userList.Add(userInfo);
            return userInfo;
        }

        /// <summary>
        /// Deletes user, if it exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public void Delete(string name, string surname)
        {
            userList.RemoveAll(user => user.Name == name && user.Surname == surname);
        }

        /// <summary>
        /// Loads Users from file
        /// </summary>
        public bool TryLoad()
        {
            try
            {
                userList.Clear();
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.json");
                string jsonString = File.ReadAllText(path);
                userList.AddRange(JsonSerializer.Deserialize<List<UserInfo>>(jsonString));
            }
            catch(ArgumentNullException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves users to file
        /// </summary>
        public bool TrySave()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string jsonUsers = JsonSerializer.Serialize(userList, options);
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.json");
                File.WriteAllText(path, jsonUsers);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            return true;
        }
    }

}