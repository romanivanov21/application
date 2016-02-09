using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interface
{
    interface IViewFind
    {
        event EventHandler dateFindRadioChecked;
        event EventHandler descriptionFindRadioChecked;
        event EventHandler findBoxsGotKeyboardFocus;

        void FindBoxSetText(string text);
    }
}
