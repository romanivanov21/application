using application.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace application.Interface
{
    internal interface IView
    {
        void ListViewUpdate(List<Entry> mainListView);
        ListView GetMainListView();

        event EventHandler MainListVliewSelectionChanged;
    }
}
