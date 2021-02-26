using System;

namespace Models
{
    public class UserEventArgs : EventArgs
    {
        public UserInfo User { get; }
        public string Message { get; }

        public UserEventArgs(UserInfo user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
