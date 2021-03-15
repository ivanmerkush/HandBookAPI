﻿using System;

namespace WindowsFormsApp
{
    class UserEventArgs : EventArgs
    {
        internal readonly string name;
        internal readonly string surname;
        internal readonly string phone;

        internal UserEventArgs(string name, string surname, string phone)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
        }
    }
}
