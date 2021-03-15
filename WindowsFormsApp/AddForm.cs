﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    partial class AddForm : Form
    {
        private readonly string pattern = @"\b^(375)+\d{9}\b";
        internal string message = string.Empty;

        internal AddForm()
        {
            InitializeComponent();
            addButton.Enabled = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Owner is UserForm userForm)
            {
                if (userForm.controller.AddUser(nameBox.Text, surnameBox.Text, phoneBox.Text))
                {
                    message = ">New user was added" + Environment.NewLine;
                }
                else
                {
                    message = ">This user already exists" + Environment.NewLine;
                }
                userForm.GetUsers();
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letter = e.KeyChar;
            if(letter == ' ')
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
