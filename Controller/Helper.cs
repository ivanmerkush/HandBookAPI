using InterfacesLibrary;

namespace Controllers
{
    public static class Helper
    {
        public static IController GetMainFormController(IUserView view) => new MainFormController(view);
        public static IController GetConsoleController(IUserView view) => new ConsoleController(view);
    }
}
