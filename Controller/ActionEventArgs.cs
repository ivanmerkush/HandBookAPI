using Models;

namespace Controllers
{
    public class ActionEventArgs : System.EventArgs
    {
        public readonly Actions action;
        public readonly UserInfo userInfo;

        public ActionEventArgs(Actions action, UserInfo userInfo)
        {
            this.action = action;
            this.userInfo = userInfo;
        }
    }

    public enum Actions
    {
        GetAll, Get, Add, Edit, Delete, Load, Save, Check
    }
}
