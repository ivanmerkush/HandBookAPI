using System;
using System.Linq;
using System.Windows.Forms;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Controllers;

namespace WindowsFormsApp
{
    using Enums;
    public partial class UserForm : Form, IUserView
    {
        private bool isEditingVisible;

        public IController Controller { get; }
        public string MessageBoxText
        {
            set
            {
                MessageBox.Show(value,
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        public string NotifierText
        {
            set
            {
                textBox.AppendText(value + Environment.NewLine);
            }
        }
        public bool EditingVisible 
        {
            get => isEditingVisible; 
            set
            {
                isEditingVisible = value;
                editButton.Enabled = isEditingVisible;
                deleteButton.Enabled = isEditingVisible;
            }
        }

        public UserForm()
        {
            Controller = Helper.GetMainFormController(this);
            InitializeComponent();
        }

        public void AddUser()
        {
            Form addForm = new SideForm(this, Operations.ADD);
            addForm.ShowDialog();
            GetUsers();
        }

        public void DeleteUser()
        {
            UserInfo user = (UserInfo) userList.SelectedItem;
            Controller.DeleteUser(user);
            GetUsers();
        }

        public void EditUser()
        {
            Form editForm = new SideForm(this, (UserInfo)userList.SelectedItem, Operations.EDIT);
            editForm.ShowDialog();
            GetUsers();
        }

        public void GetUser()
        {
            Form getForm = new GetForm();
            getForm.ShowDialog();
        }

        public void GetUsers()
        {
            userList.Items.Clear();
            userList.Items.AddRange(Controller.GetUsers().ToArray());
        }

        public void LoadDB()
        {
            Controller.LoadDB();
            GetUsers();
        }

        public void SaveDB()
        {
            Controller.SaveDB();
        }

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
            EditingVisible = true;
        }
    }
}
