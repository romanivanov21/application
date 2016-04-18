using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interface
{
    internal interface IViewFind
    {
        event EventHandler dateFindRadioChecked;
        event EventHandler descriptionFindRadioChecked;
        event EventHandler findBoxsGotKeyboardFocus;
        event EventHandler findButtonClick;
        event EventHandler mainCalendarSelectedDatesChanged;

        void FindBoxSetText(string text);
        string GetFindBoxText();
        string GetSelectedMainCalendarDate();
        bool isDateFindRadiEnabeled();
    }
}
