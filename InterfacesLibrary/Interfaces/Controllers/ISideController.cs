using InterfacesLibrary.Interfaces.Views;
using Models;

namespace InterfacesLibrary.Interfaces.Controllers
{
    public interface ISideController
    {
        IModel Model { get; }
        ISideView SideView { get; }
        void ExecuteOperation(UserInfo user);
    }
}
