using InterfacesLibrary.Interfaces.Views;
using InterfacesLibrary.Interfaces.Controllers;
using Controllers.Impl;
using Models;
namespace Controllers
{
    public static class Helper
    {
        public static IController GetMainFormController(IUserView view) => new MainFormController(view);
        public static IController GetConsoleController(IUserView view) => new ConsoleController(view);
        public static ISideController GetAddFormController(ISideView sideView) => new AddFormController(sideView);
        public static ISideController GetEditFormController(ISideView sideView) => new EditFormController(sideView);
        public static IInfoController GetInfoController(IGetView getView) => new GetController(getView);
    }
}
