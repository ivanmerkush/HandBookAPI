namespace Views
{
    /// <summary>
    /// Containts standart methods to work with list of users
    /// </summary>
    public interface IHandbookView
    {
        void GetUsers();

        void GetUserByNameAndSurname();

        void AddUser();

        void EditUser();

        void DeleteUser();

        void LoadDB();

        void SaveDB();
    }
}
