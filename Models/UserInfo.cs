
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

        public override string ToString() => string.Join(" ", Name, Surname, Phone);
    }
}
