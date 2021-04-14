using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using Models;
using System.ComponentModel;
using InterfacesLibrary;

namespace WindowsFormsApp
{
    internal partial class GetForm : Form
    {
        private readonly IController controller;
        private readonly string pattern = @"\b^(375)+\d{9}\b";

        private GetForm()
        {
            InitializeComponent();
        }

        public GetForm(IController controller)
        {
            phoneBox.Validating += PhoneValidating;
            nameBox.Validating += NameValidating;
            surnameBox.Validating += SurnameValidating;
            this.controller = controller;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == pageName)
            {
                usersBox.Items.Clear();
                if (nameBox.Text != string.Empty && surnameBox.Text != string.Empty)
                {       
                    usersBox.Items.AddRange(controller.GetUserByName(nameBox.Text, surnameBox.Text).ToArray());
                }
            }
            else
            {
                userBox.Clear();
                if (Regex.IsMatch(phoneBox.Text, pattern))
                {
                    //if (Owner is UserForm userForm)
                    //{
                    //    UserInfo user = userForm.Controller.GetUserByPhone(phoneBox.Text);
                    //    if (user != null)
                    //    {
                    //        userBox.Text = user.ToString();
                    //    }
                    //    else
                    //    {
                    //        userBox.Text = "Not found";
                    //    }
                    //}
                }
            }
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

        private void NameValidating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(nameBox.Text))
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
            if(Regex.IsMatch(phoneBox.Text, pattern))
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
