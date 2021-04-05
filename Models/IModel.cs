using System;
using System.Collections.Generic;
using System.Text;

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
        UserInfo Add(string name, string surname, string phone);
        void Edit(UserInfo oldElement, UserInfo editedElement);
        void Delete(string name, string surname);
    }
}
