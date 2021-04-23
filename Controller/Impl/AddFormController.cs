using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Models;

namespace Controllers.Impl
{
    class AddFormController : ISideController
    {
        public IModel Model { get; }

        public ISideView SideView { get; }

        internal AddFormController(ISideView sideView)
        {
            Model = Users.Instance;
            SideView = sideView;
            SideView.ButtonText = "Add";
        }

        public void ExecuteOperation(UserInfo user)
        {
            if (Model.Exists(user.Phone))
            {
                SideView.NotifierText = ">This user already exists";
            }
            else
            {
                Model.Add(user);
                SideView.NotifierText = ">New user was added";
            }
        }
    }
}
