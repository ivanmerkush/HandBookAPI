using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;

namespace WinFormsInterface
{
    internal partial class EditForm : Form
    {
        private readonly UserInfo userInfo;
        private readonly Regex phoneRegex = new Regex(@"^(375)+\d{9}");

        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(UserInfo userInfo)
        {
            InitializeComponent();
            this.userInfo = userInfo;
            nameBox.Text = userInfo.Name;
            surnameBox.Text = userInfo.Surname;
            phoneBox.Text = userInfo.Phone;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == string.Empty || surnameBox.Text == string.Empty || phoneBox.Text == string.Empty)
            {
                MessageBox.Show("Fill all fields",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button1,
                               MessageBoxOptions.DefaultDesktopOnly);
            }
            if (phoneRegex.Matches(phoneBox.Text).Count > 0)
            {
                if (Owner is UserForm userForm)
                {
                    if(userForm.controller.EditUser( userInfo, nameBox.Text, surnameBox.Text, phoneBox.Text))
                    {
                        userForm.textBox.AppendText(">User was edited." + Environment.NewLine);
                        userForm.GetUsers();
                    }
                    else
                    {
                        userForm.textBox.AppendText("Not unique attributes" + Environment.NewLine);
                    }
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Type again your phone number",
                               "Wrong phone number",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button1,
                               MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
