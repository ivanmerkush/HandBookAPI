using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;

namespace WindowsFormsApp
{
    public partial class GetForm : Form
    {

        private readonly string pattern = @"\b^(375)+\d{9}\b";

        public GetForm()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == pageName)
            {
                usersBox.Items.Clear();
                if (nameBox.Text != string.Empty && surnameBox.Text != string.Empty)
                {
                    if(Owner is UserForm userForm)
                    {
                        usersBox.Items.AddRange(userForm.controller.GetUserByName(nameBox.Text, surnameBox.Text).ToArray());
                    }
                }
            }
            else
            {
                userBox.Clear();
                if (Regex.IsMatch(phoneBox.Text, pattern))
                {
                    if (Owner is UserForm userForm)
                    {
                        UserInfo user = userForm.controller.GetUserByPhone(phoneBox.Text);
                        if(user != null)
                        {
                            userBox.Text = user.ToString();
                        }
                        else
                        {
                            userBox.Text = "Not found";
                        }
                    }
                }
            }
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (letter == ' ')
            {
                e.Handled = true;
            }
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (!char.IsDigit(letter) && letter != 8)
            {
                e.Handled = true;
            }
        }
    }
}
