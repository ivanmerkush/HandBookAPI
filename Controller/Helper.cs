using InterfacesLibrary.Interfaces.Views;
using InterfacesLibrary.Interfaces.Controllers;
using Controllers.Impl;
using Models;
namespace Controllers
{
    public static class Helper
    {
        private static IModel model;

        public static IModel Users
        {
            get => model ??= new Users();
        }
        public static IController GetMainFormController(IUserView view) => new MainFormController(view, Users);
        public static IController GetConsoleController(IUserView view) => new ConsoleController(view, Users);
        public static ISideController GetAddFormController(ISideView sideView) => new AddFormController(sideView, Users);
        public static ISideController GetEditFormController(ISideView sideView) => new EditFormController(sideView, Users);
        public static IInfoController GetInfoController(IGetView getView) => new GetController(getView, Users);
    }
}
