using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace InterfacesLibrary.Interfaces.Controllers
{
    using Views;
    public interface IInfoController
    {
        IModel Model { get; }
        IGetView View { get; }
        IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname);
        UserInfo GetUserByPhone(string phone);
    }
}
