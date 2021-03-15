using System;

namespace WindowsFormsApp
{
    class PhoneEventArgs : EventArgs
    {
        internal readonly string phone;

        public PhoneEventArgs(string phone)
        {
            this.phone = phone;
        }
    }
}
