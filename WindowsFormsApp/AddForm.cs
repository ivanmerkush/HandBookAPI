using Controllers;
using InterfacesLibrary.Interfaces.Views;
using Models;

namespace WindowsFormsApp
{
    public partial class AddForm : SideForm
    {
        private AddForm()
        {
            InitializeComponent();
        }

        public AddForm(IUserView view) : base(view)
        {
            InitializeComponent();
            SideController = Helper.GetAddFormController(this);
            executeButton.Text = "Add";
        }

        public override void Execute()
        {
            SideController.ExecuteOperation(new UserInfo(nameBox.Text, surnameBox.Text, phoneBox.Text));
        }
    }
}
