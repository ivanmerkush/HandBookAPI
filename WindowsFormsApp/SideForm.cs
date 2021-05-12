using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Controllers;

namespace WindowsFormsApp
{
    public partial class SideForm : Form, ISideView
    {
        private IUserView mainView;
        public ISideController SideController { get; internal set; }
        protected readonly UserInfo oldUser;
        private readonly string pattern = @"\b^(375)+\d{9}\b";

        protected SideForm()
        {
            InitializeComponent();
        }

        protected SideForm(IUserView view)
        {
            InitializeSideForm(view);
        }

        protected SideForm(IUserView view, UserInfo userInfo)
        {
            InitializeSideForm(view);
            oldUser = userInfo;
            nameBox.Text = userInfo.Name;
            surnameBox.Text = userInfo.Surname;
            phoneBox.Text = userInfo.Phone;
        }

        private void InitializeSideForm(IUserView view)
        {
            InitializeComponent();
            phoneBox.Validating += PhoneValidating;
            nameBox.Validating += NameValidating;
            surnameBox.Validating += SurnameValidating;
            mainView = view;
        }

        public void EnableEdittingUsers()
        {
            mainView.EnableEdittingUsers();
        }

        public void DisableEdittingUsers()
        {
            mainView.DisableEdittingUsers();
        }

        public void ShowMessageBox(string text) => mainView.ShowMessageBox(text);
        public void AppendNotifierText(string text) => mainView.AppendNotifierText(text);

        private void EditButton_Click(object sender, EventArgs e)
        {
            Execute();
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
                executeButton.Enabled = false;
            }
            else
            {
                executeButton.Enabled = true;
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

        public virtual void Execute()
        {
            
        }
    }
}
