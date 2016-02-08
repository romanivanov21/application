using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace application.Interface
{
    interface IView
    {
        void WindowInit(List<Entry> mainListView);
    }
}
