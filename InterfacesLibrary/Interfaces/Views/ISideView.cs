using InterfacesLibrary.Interfaces.Controllers;

namespace InterfacesLibrary.Interfaces.Views
{
    public interface ISideView
    {
        string MessageBoxText { set; }
        string NotifierText { set; }
        bool EditingVisible { get; set; }
        string ButtonText { set; }
        ISideController SideController { get; }
        void Execute();
    }
}
