using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal string Phone { get; set; }
        
        internal UserInfo(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override bool Equals(object obj) => Equals(obj as UserInfo);

        public bool Equals(UserInfo userInfo)
        {
            if(userInfo == null)
            {
                return false;
            }
            return Name.Equals(userInfo.Name) && 
                   Surname.Equals(userInfo.Surname) && 
                   Phone.Equals(userInfo.Phone);
        }

        /// <summary>
        /// Changes one of attributes depending on parameter value
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="parameter"></param>
        public void ChangeValue(string newValue, Parameter parameter)
        {
            switch(parameter)
            {
                case Parameter.Name:
                    Name = newValue;
                    break;
                case Parameter.Surname:
                    Surname = newValue;
                    break;
                case Parameter.Phone:
                    Phone = newValue;
                    break;
            }
        }

        public override int GetHashCode() => Name.GetHashCode() + Surname.GetHashCode() + Phone.GetHashCode();

        public override string ToString() => Name + " " + Surname + " " + Phone;
    }
}
