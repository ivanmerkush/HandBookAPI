using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;

namespace WindowsFormsApp
{
    internal partial class EditForm : Form
    {
        internal event EventHandler<UserEventArgs> UserEdited;
        private readonly string pattern = @"\b^(375)+\d{9}\b";
        
        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(UserInfo userInfo)
        {
            InitializeComponent();
            nameBox.Text = userInfo.Name;
            surnameBox.Text = userInfo.Surname;
            phoneBox.Text = userInfo.Phone;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            UserEdited(this, new UserEventArgs(nameBox.Text, surnameBox.Text, phoneBox.Text));
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameBox.Text == string.Empty || surnameBox.Text == string.Empty || !Regex.IsMatch(phoneBox.Text, pattern))
            {
                editButton.Enabled = false;
            }
            else
            {
                editButton.Enabled = true;
            }
        }
    }
}
