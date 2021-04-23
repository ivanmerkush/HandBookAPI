using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesLibrary.Interfaces.Views
{
    using Controllers;
    public interface IGetView
    {
        IInfoController InfoController { get; }
        string PhoneText { set; }
    }
}
