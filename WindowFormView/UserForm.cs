using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Views;
using Controllers;
using Models;

namespace WinFormsInterface
{
    public partial class UserForm : Form, IHandbookView
    {
        internal readonly IController controller;

        public UserForm()
        {
            controller = new BookController();
            InitializeComponent();
        }

        public void AddUser()
        {
            AddForm addForm = new AddForm
            {
                Owner = this
            };
            addForm.ShowDialog();

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
            EditForm editForm = new EditForm((UserInfo)userList.SelectedItem)
            {
                Owner = this
            };
            editForm.ShowDialog();
        }

        public void GetUser()
        {

        }

        public void GetUsers()
        {
            userList.Items.Clear();
            userList.Items.AddRange(controller.GetUsers().ToArray());
        }

        public void LoadDB()
        {
            if(controller.LoadDB())
            {
                textBox.AppendText(">Users were successfully loaded from file." + Environment.NewLine);
                GetUsers();
            }
            else
            {
                MessageBox.Show("Problem happened during loading users",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public void SaveDB()
        {
            if(controller.SaveDB())
            {
                textBox.AppendText(">Users were successfully saved to file." + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Problem happened during saving users",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
            }

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
