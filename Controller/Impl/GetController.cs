using System;
using System.Collections.Generic;
using System.Text;
using InterfacesLibrary.Interfaces.Views;
using InterfacesLibrary.Interfaces.Controllers;
using Models;

namespace Controllers.Impl
{
    class GetController : IInfoController
    {
        public IModel Model { get; }
        public IGetView View { get; }

        internal GetController(IGetView view)
        {
            Model = Users.Instance;
            View = view;
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            return Model.GetUser(name, surname);
        }

        public UserInfo GetUserByPhone(string phone)
        {
            UserInfo userInfo = Model.GetUser(phone);
            if(userInfo == null)
            {
                View.PhoneText = "Not found";
            }
            return userInfo;
        }
    }
}
