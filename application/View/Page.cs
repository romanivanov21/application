using System.Collections.Generic;
using System.Windows.Controls;
using application.Model;

namespace application.View
{
    internal class Page
    {
        public Page(ListView listView, Grid gridPanel)
        {
            _layout = new NavigationLayout(gridPanel);
            _listView = listView;
        }

        public void Drow(ButtonsLayout buttonsLayout, List<Entry> currentEntries)
        {
            _layout.DrowButtons(buttonsLayout);
            _listView.ItemsSource = currentEntries;
            _listView.Items.Refresh();
        }

        private readonly ListView _listView;
        private readonly NavigationLayout _layout;
    }
}
