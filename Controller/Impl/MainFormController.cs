using System;
using System.Collections.Generic;
using Models;
using InterfacesLibrary;

namespace Controllers
{
    /// <summary>
    /// Allows to review and edit list of users infromtaion
    /// </summary>
    class MainFormController : IController
    {
        private readonly IModel model;
        private readonly IUserView view;   

        internal MainFormController(IUserView view)
        {
            model = new Users();
            this.view = view;
        }

        public IReadOnlyCollection<UserInfo> GetUsers()
        {
            return model.GetAll();
        }

        public IReadOnlyCollection<UserInfo> GetUserByName(string name, string surname)
        {
            return model.GetUser(name, surname);
        }

        public UserInfo GetUserByPhone(string phone)
        {
            return model.GetUser(phone);
        }        

        /// <summary>
        /// Adds new user with values of name surname and phone
        /// </summary>
        /// <param name="users"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool AddUser(string name, string surname, string phone)
        {
            //if (model.Exists(phone))
            //{
            //    view.textBox.AppendText(">This user already exists" + Environment.NewLine);
            //}

            //if (controller.AddUser(e.name, e.surname, e.phone))
            //{
            //    textBox.AppendText(">New user was added" + Environment.NewLine);
            //    GetUsers();
            //}
            //else
            //{

            //}
            model.Add(name, surname, phone);
            return true;
        }

        public bool EditUser(UserInfo user, string name, string surname, string phone)
        {
            if (model.Exists(name, surname, phone))
            {
                return false;
            }
            model.Edit(user, new UserInfo(name, surname, phone));
            return true;
        }

        public bool DeleteUser(string name, string surname)
        {
            if (model.Exists(name, surname))
            {
                model.Delete(name, surname);
                return true;
            }
            return false;
        }

        public void LoadDB()
        {
            //if (model is Users users)
            //{
            //    if(users.TryLoad())
            //    {
            //        if(view is )
            //        view.TextBox.AppendText(">Users were successfully loaded from file." + Environment.NewLine);
            //        GetUsers();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Problem happened during loading users",
            //                        "Error",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Error,
            //                        MessageBoxDefaultButton.Button1,
            //                        MessageBoxOptions.DefaultDesktopOnly);
            //    }
            //}
        }

        public void SaveDB()
        {
            model.TrySave();
        }
    }
}
