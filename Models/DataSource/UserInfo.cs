using System;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        internal static int idCounter = 1;

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        internal UserInfo()
        {
            idCounter++;
        }

        /// <summary>
        /// Creates userInfo with a new Id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        public UserInfo(string name, string surname, string phone)
        {
            Id = idCounter++;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        /// <summary>
        /// Creates userInfo with an old Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        public UserInfo(int id, string name, string surname, string phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override string ToString() => string.Join(" ", Id, Name, Surname, Phone);

        public override bool Equals(object obj)
        {
            return obj is UserInfo info &&
                   Name == info.Name &&
                   Surname == info.Surname &&
                   Phone == info.Phone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Phone);
        }
    }
}