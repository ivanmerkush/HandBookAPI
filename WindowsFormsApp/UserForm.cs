using System;
using System.Linq;
using System.Windows.Forms;
using Models;
using ControllerAndViewAbstraction;
using DIContainer;

namespace WindowsFormsApp
{
    public partial class UserForm : Form, IUserView
    {
        internal readonly IController controller;

        public UserForm()
        {
            controller = Helper.GetMainFormController(this);
            InitializeComponent();
        }

        public void AddUser()
        {
            AddForm addForm = new AddForm();
            addForm.UserAdded += AddEventHandler;
            addForm.ShowDialog();
            addForm.UserAdded -= AddEventHandler;

        }

        private void AddEventHandler(object sender, UserEventArgs e)
        {
        }

        public void DeleteUser()
        {
            UserInfo user = (UserInfo) userList.SelectedItem;
            controller.DeleteUser(user.Name, user.Surname);
            textBox.AppendText(">User was deleted." + Environment.NewLine);
            GetUsers();
            editButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        public void EditUser()
        {
            EditForm editForm = new EditForm((UserInfo)userList.SelectedItem);
            editForm.UserEdited += EditEventHandler;
            editForm.ShowDialog();
            editForm.UserEdited -= EditEventHandler;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        private void EditEventHandler(object sender, UserEventArgs e)
        {
            if (controller.EditUser((UserInfo)userList.SelectedItem, e.name, e.surname, e.phone))
            {
                textBox.AppendText(">User was edited." + Environment.NewLine);
                GetUsers();
            }
            else
            {
                textBox.AppendText(">Not unique attributes" + Environment.NewLine);
            }
        }

        public void GetUser()
        {
            GetForm getForm = new GetForm()
            {
                Owner = this
            };
            getForm.ShowDialog();
        }

        public void GetUsers()
        {
            userList.Items.Clear();
            userList.Items.AddRange(controller.GetUsers().ToArray());
        }

        public void LoadDB()
        {
            controller.LoadDB();
            GetUsers();
            
        }

        public void SaveDB()
        {
            //if(controller.SaveDB())
            //{
            //    textBox.AppendText(">Users were successfully saved to file." + Environment.NewLine);
            //}
            //else
            //{
            //    MessageBox.Show("Problem happened during saving users",
            //                    "Error",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error,
            //                    MessageBoxDefaultButton.Button1,
            //                    MessageBoxOptions.DefaultDesktopOnly);
            //}

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
            editButton.Enabled = true;
            deleteButton.Enabled = true;
        }
    }
}
