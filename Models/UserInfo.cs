using System.Text.Json.Serialization;

namespace Models
{
    /// <summary>
    /// Represents simple information about user: name and phone
    /// </summary>
    public class UserInfo
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Surname")]
        public string Surname { get; set; }
        [JsonPropertyName("Phone")]
        public string Phone { get; set; }
        
        internal UserInfo()
        {

        }

        internal UserInfo(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override string ToString() => string.Join(" ", Name, Surname, Phone);
    }
}
