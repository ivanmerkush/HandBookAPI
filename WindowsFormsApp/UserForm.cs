using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Controllers;

namespace WindowsFormsApp
{
    public partial class UserForm : Form, IUserView
    {
        public IController Controller { get; }

        public UserForm()
        {
            Controller = Helper.GetMainFormController(this);
            InitializeComponent();
        }

        public void EnableEdittingUsers()
        {
            editButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        public void DisableEdittingUsers()
        {
            editButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        public void AddUser()
        {
            SideForm addForm = new AddForm(this);
            addForm.ShowDialog();
            UpdateUsersBox();
        }

        public void DeleteUser()
        {
            UserInfo user = (UserInfo) userList.SelectedItem;
            Controller.DeleteUser(user);
            UpdateUsersBox();
        }

        public void EditUser()
        {
            SideForm editForm = new EditForm(this, (UserInfo)userList.SelectedItem);
            editForm.ShowDialog();
            UpdateUsersBox();
        }

        public void GetUser()
        {
            Form getForm = new GetForm();
            getForm.ShowDialog();
        }

        public IReadOnlyCollection<UserInfo> GetUsers() => Controller.GetUsers();

        private void UpdateUsersBox()
        {
            userList.Items.Clear();
            userList.Items.AddRange(GetUsers().ToArray());
        }

        public void LoadDB()
        {
            Controller.LoadDB();
            UpdateUsersBox();
        }

        public void SaveDB()
        {
            Controller.SaveDB();
        }

        public void ShowMessageBox(string text) => MessageBox.Show(text,
                                                   "Message",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information,
                                                   MessageBoxDefaultButton.Button1,
                                                   MessageBoxOptions.DefaultDesktopOnly);

        public void AppendNotifierText(string text) => textBox.AppendText(text + Environment.NewLine);

        private void GetButton_Click(object sender, EventArgs e)
        {
            GetUser();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadDB();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableEdittingUsers();
        }

        private void userGridView_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
