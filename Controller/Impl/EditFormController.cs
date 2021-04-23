using System;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Models;

namespace Controllers.Impl
{
    class EditFormController : ISideController
    {
        public IModel Model { get; }
        public ISideView SideView { get; }

        internal EditFormController(ISideView sideView)
        {
            Model = Users.Instance;
            SideView = sideView;
            SideView.ButtonText = "Edit";
        }

        public void ExecuteOperation(UserInfo editedUser)
        {
            if (Model.Exists(editedUser.Name, editedUser.Surname, editedUser.Phone))
            {
                SideView.MessageBoxText = "Not unique attributes";
            }
            else
            {
                SideView.NotifierText = ">User was edited.";
                Model.Edit(editedUser);
                SideView.EditingVisible = false;
            }
        }
    }
}
