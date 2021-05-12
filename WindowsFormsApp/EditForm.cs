using Controllers;
using InterfacesLibrary.Interfaces.Views;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class EditForm : SideForm
    {
        private EditForm()
        {
            InitializeComponent();
        }

        public EditForm(IUserView view, UserInfo userInfo) : base(view, userInfo)
        {
            InitializeComponent();
            SideController = Helper.GetEditFormController(this);
            executeButton.Text = "Edit";
        }

        public override void Execute()
        {
            SideController.ExecuteOperation(new UserInfo(oldUser.Id, nameBox.Text, surnameBox.Text, phoneBox.Text));
        }
    }
}
