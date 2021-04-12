using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using InterfacesLibrary;

namespace WindowsFormsApp
{
    partial class AddForm : Form
    {
        private readonly IController controller;
        private readonly string pattern = @"\b^(375)+\d{9}\b";
        
        private AddForm()
        {
            InitializeComponent();
        }

        internal AddForm(IController controller)
        {
            InitializeComponent();
            addButton.Enabled = false;
            phoneBox.Validating += PhoneValidating;
            nameBox.Validating += NameValidating;
            surnameBox.Validating += SurnameValidating;
            this.controller = controller;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            controller.AddUser(nameBox.Text, surnameBox.Text, phoneBox.Text);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if ((letter != ' ' && letter == 8) || Regex.IsMatch(letter.ToString(), "[a-zA-Z0-9]", RegexOptions.IgnoreCase))
            {
                return;
            }
            e.Handled = true;
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

        private void NameValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                errorProvider1.SetError(nameBox, "No name specified");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void SurnameValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(surnameBox.Text))
            {
                errorProvider1.SetError(surnameBox, "No surname specified");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void PhoneValidating(object sender, CancelEventArgs e)
        {
            if (Regex.IsMatch(phoneBox.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(phoneBox, "Phone number should look like 375XXXXXXXXX, where X is any digit.");
            }
        }
    }
}
