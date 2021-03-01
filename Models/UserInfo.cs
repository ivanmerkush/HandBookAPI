
namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        internal string Name { get; private set; }
        internal string Surname { get; private set; }
        internal string Phone { get; private set; }

        internal UserInfo(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override bool Equals(object obj) => Equals(obj as UserInfo);

        public bool Equals(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return false;
            }
            return Name.Equals(userInfo.Name) &&
                   Surname.Equals(userInfo.Surname);
        }

        /// <summary>
        /// Changes one of attributes depending on parameter value
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="parameter"></param>
        public UserInfo ChangeValue(string newValue, Parameters parameter)
        {
            switch (parameter)
            {
                case Parameters.Name:
                    Name = newValue;
                    break;
                case Parameters.Surname:
                    Surname = newValue;
                    break;
                case Parameters.Phone:
                    Phone = newValue;
                    break;
            }
            return this;
        }

        public override int GetHashCode() => Name.GetHashCode() + 13 * Surname.GetHashCode();

        public override string ToString() => string.Join(" ", Name, Surname, Phone);
    }
}
