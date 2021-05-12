using System.Collections.Generic;

namespace Models
{
    public interface IModel
    {
        IReadOnlyCollection<UserInfo> GetAll();
        IReadOnlyCollection<UserInfo> GetUser(string name, string surname);
        UserInfo GetUser(string phone);
        bool Exists(string phone);
        bool Exists(string name, string surname);
        bool Exists(string name, string surname, string phone);
        void Add(UserInfo user);
        void Edit(UserInfo editedElement);
        void Delete(string name, string surname);
        bool TryLoad();
        bool TrySave();
    }
}
