
namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Phone { get; internal set; }
        
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

        public override int GetHashCode() => Name.GetHashCode() + 13 * Surname.GetHashCode();

        public override string ToString() => string.Join(" ", Name, Surname, Phone);
    }
}
