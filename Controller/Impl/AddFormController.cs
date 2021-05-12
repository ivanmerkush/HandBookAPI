using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Models;

namespace Controllers.Impl
{
    class AddFormController : ISideController
    {
        public IModel Model { get; }

        public ISideView SideView { get; }

        internal AddFormController(ISideView sideView, IModel model)
        {
            Model = model;
            SideView = sideView;
        }

        public void ExecuteOperation(UserInfo user)
        {
            if (Model.Exists(user.Phone))
            {
                SideView.AppendNotifierText(">This user already exists");
            }
            else
            {
                Model.Add(user);
                SideView.AppendNotifierText(">New user was added");
            }
        }
    }
}
