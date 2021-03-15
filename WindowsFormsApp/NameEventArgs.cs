using System;

namespace WindowsFormsApp
{
    class NameEventArgs : EventArgs
    {
        internal readonly string name;
        internal readonly string surname;

        public NameEventArgs(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }
}
