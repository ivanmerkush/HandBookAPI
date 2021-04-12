namespace InterfacesLibrary
{
    /// <summary>
    /// Containts standart methods to work with list of users
    /// </summary>
    public interface IUserView
    {
        IController Controller { get; }
        string MessageBoxText { set; }
        string NotifierText { set; }
        void GetUsers();
        void GetUser();
        void AddUser();
        void EditUser();
        void DeleteUser();
        void LoadDB();
        void SaveDB();
    }
}
