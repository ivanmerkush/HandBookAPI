using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Models;
using InterfacesLibrary.Interfaces.Controllers;
using InterfacesLibrary.Interfaces.Views;
using Controllers;
using WindowsFormsApp.Enums;

namespace WindowsFormsApp
{
    internal partial class SideForm : Form, ISideView
    {
        private readonly IUserView mainView;
        private readonly UserInfo oldUser;
        private readonly string pattern = @"\b^(375)+\d{9}\b";

        public string ButtonText { set => executeButton.Text = value; }
        public ISideController SideController { get; }
        public string MessageBoxText 
        { 
            set => mainView.MessageBoxText = value;
        }
        public string NotifierText { set => mainView.NotifierText = value; }
        public bool EditingVisible 
        { 
            get => mainView.EditingVisible; 
            set => mainView.EditingVisible = value; 
        }

        private SideForm()
        {
            InitializeComponent();
        }

        public SideForm(IUserView view, Operations operation)
        {
            InitializeComponent();
            phoneBox.Validating += PhoneValidating;
            nameBox.Validating += NameValidating;
            surnameBox.Validating += SurnameValidating;
            mainView = view;
            if (operation == Operations.ADD)
            {
                SideController = Helper.GetAddFormController(this);
            }
            else
            {
                if(operation == Operations.EDIT)
                {
                    SideController = Helper.GetEditFormController(this);
                }
            }
        }

        public SideForm(IUserView view, UserInfo userInfo, Operations operation)
        {
            InitializeComponent();
            oldUser = userInfo;
            nameBox.Text = userInfo.Name;
            surnameBox.Text = userInfo.Surname;
            phoneBox.Text = userInfo.Phone;
            phoneBox.Validating += PhoneValidating;
            nameBox.Validating += NameValidating;
            surnameBox.Validating += SurnameValidating;
            mainView = view;
            if (operation == Operations.ADD)
            {
                SideController = Helper.GetAddFormController(this);
                executeButton.Text = "Add";
            }
            else
            {
                SideController = Helper.GetEditFormController(this);
                executeButton.Text = "Edit";
            }
        }

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

        public void Execute()
        {
            if (oldUser != null)
            {
                SideController.ExecuteOperation(new UserInfo(oldUser.Id, nameBox.Text, surnameBox.Text, phoneBox.Text));
            }
            else
            {
                SideController.ExecuteOperation(new UserInfo(nameBox.Text, surnameBox.Text, phoneBox.Text));
            }
        }
    }
}
