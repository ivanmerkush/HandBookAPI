using InterfacesLibrary.Interfaces.Controllers;

namespace InterfacesLibrary.Interfaces.Views
{
    public interface ISideView
    {
        ISideController SideController { get; }

        void ShowMessageBox(string text);
        void AppendNotifierText(string text);
        void EnableEdittingUsers();
        void DisableEdittingUsers();
        void Execute();
    }
}
