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

        internal EditFormController(ISideView sideView, IModel model)
        {
            Model = model;
            SideView = sideView;
        }

        public void ExecuteOperation(UserInfo editedUser)
        {
            if (Model.Exists(editedUser.Name, editedUser.Surname, editedUser.Phone))
            {
                SideView.ShowMessageBox("Not unique attributes");
            }
            else
            {
                SideView.AppendNotifierText(">User was edited.");
                Model.Edit(editedUser);
                SideView.DisableEdittingUsers();
            }
        }
    }
}
