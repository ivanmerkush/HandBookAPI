using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Models
{
    public class Users
    {
        public List<UserInfo> UserList { get; }
        
        public Users()
        {
            UserList = new List<UserInfo>();
        }

        public UserInfo GetUser(string value, Parameter parameter)
        {
            switch(parameter)
            {
                case Parameter.Name:
                    return UserList.Find(user => user.Name.Equals(value));
                case Parameter.Surname:
                    return UserList.Find(user => user.Surname.Equals(value));
                case Parameter.Phone:
                    return UserList.Find(user => user.Phone.Equals(value));
                default:
                    return null;
            }
        }

        public bool Exists(string name, string surname)
        {
            return UserList.Exists(user => user.Name.Equals(name) && 
                                           user.Surname.Equals(surname));
        }

        public bool Exists(string phone) => UserList.Exists(user => user.Phone.Equals(phone));

        public void EditInfo(UserInfo userInfo, string newValue, Parameter parameter)
        {
            if(UserList.Contains(userInfo))
            {
                foreach (UserInfo user in UserList)
                {
                    if (user.Equals(userInfo))
                    {
                        user.ChangeValue(newValue, parameter);
                        break;
                    }
                }
            }
            
        }

        public void AddUserInfo(string name, string surname, string phone) => UserList.Add(new UserInfo(name, surname, phone));

        public void DeleteUser(string name, string surname)
        {
            UserList.RemoveAll(user => user.Name.Equals(name) && user.Surname.Equals(surname));
        }

        public void LoadUsers()
        {
            try
            {
                UserList.Clear();
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.txt");
                string text = File.ReadAllText(path);
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] parameters = lines[i].Split(' ');
                    UserList.Add(new UserInfo(parameters[0], parameters[1], parameters[2]));
                }
            }
            catch (IOException)
            {

            }
            
        }

        public void SaveUsers()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(UserInfo userInfo in UserList)
                {
                    stringBuilder.Append(userInfo.ToString()).Append("\n");
                }
                string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, @"Files\Users.txt");
                File.WriteAllText(path, stringBuilder.ToString());
            }
            catch(IOException)
            {

            }
            
        }
    }

    public enum Parameter
    {
        Name, Surname, Phone
    };
}
