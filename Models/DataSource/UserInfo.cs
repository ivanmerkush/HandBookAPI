using System;
using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        private static int id = 1;

        [JsonIgnore]
        public int Id { get; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }

        internal UserInfo()
        {
            Id = id++;
        }

        public UserInfo(string name, string surname, string phone)
        {
            Id = id++;
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override string ToString() => string.Join(" ", Id, Name, Surname, Phone);

        public override bool Equals(object obj)
        {
            return obj is UserInfo info &&
                   Name == info.Name &&
                   Surname == info.Surname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname);
        }
    }
}