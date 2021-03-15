using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    partial class AddForm : Form
    {
        internal event EventHandler<UserEventArgs> UserAdded;
        private readonly string pattern = @"\b^(375)+\d{9}\b";

        internal AddForm()
        {
            InitializeComponent();
            addButton.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            UserAdded?.Invoke(this, new UserEventArgs(nameBox.Text, surnameBox.Text, phoneBox.Text));
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if (letter == ' ' || !Regex.IsMatch(letter.ToString(),"[a-zA-Z0-9]", RegexOptions.IgnoreCase))
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
                addButton.Enabled = false;
            }
            else
            {
                addButton.Enabled = true;
            }
        }
    }
}
