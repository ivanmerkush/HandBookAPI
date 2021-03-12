using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsInterface
{
    partial class AddForm : Form
    {
        private readonly Regex phoneRegex = new Regex(@"^(375)+\d{9}");

        public AddForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(nameBox.Text == string.Empty || surnameBox.Text == string.Empty || phoneBox.Text == string.Empty)
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
                    if(userForm.controller.AddUser(nameBox.Text, surnameBox.Text, phoneBox.Text))
                    {
                        userForm.textBox.AppendText("New user was added" + Environment.NewLine);
                    }
                    else
                    {
                        userForm.textBox.AppendText("This user already exists" + Environment.NewLine);
                    }
                    userForm.GetUsers();
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
