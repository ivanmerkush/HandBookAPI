using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp
{
    class UserEventArgs : EventArgs
    {
        internal string name;
        internal string surname;
        internal string phone;

        internal UserEventArgs(string name, string surname, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }
    }
}
