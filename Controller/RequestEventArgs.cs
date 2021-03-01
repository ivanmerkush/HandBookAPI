using Models;

namespace Controllers
{
    public class RequestEventArgs : System.EventArgs
    {
        public readonly string message;
        public readonly UserInfo userInfo;

        public RequestEventArgs(string message, UserInfo userInfo)
        {
            this.message = message;
            this.userInfo = userInfo;
        }
    }
}
