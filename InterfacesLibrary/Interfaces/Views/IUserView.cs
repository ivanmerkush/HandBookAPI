using System.Collections.Generic;
using Models;
using InterfacesLibrary.Interfaces.Controllers;

namespace InterfacesLibrary.Interfaces.Views
{
    /// <summary>
    /// Containts standart methods to work with list of users
    /// </summary>
    public interface IUserView
    {
        IController Controller { get; }

        void EnableEdittingUsers();
        void DisableEdittingUsers();
        void ShowMessageBox(string text);
        void AppendNotifierText(string text);
        IReadOnlyCollection<UserInfo> GetUsers();
        void GetUser();
        void AddUser();
        void EditUser();
        void DeleteUser();
        void LoadDB();
        void SaveDB();
    }
}
