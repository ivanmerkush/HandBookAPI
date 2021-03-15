using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;

namespace WindowsFormsApp
{
    internal partial class GetForm : Form
    {
        internal event EventHandler<PhoneEventArgs> GetByPhone;
        internal event EventHandler<NameEventArgs> GetByName;
        internal UserInfo user;
        internal UserInfo[] users; 
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
                    GetByName.Invoke(this, new NameEventArgs(nameBox.Text, surnameBox.Text));
                    usersBox.Items.AddRange(users);
                }
            }
            else
            {
                userBox.Clear();
                if (Regex.IsMatch(phoneBox.Text, pattern))
                {
                    GetByPhone.Invoke(this, new PhoneEventArgs(phoneBox.Text));
                    if (user != null)
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
