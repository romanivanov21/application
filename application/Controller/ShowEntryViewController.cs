using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using application.Common;
using application.Interface;
using application.View;

namespace application.Controller
{
    internal class ShowEntryViewController
    {
        public ShowEntryViewController(IShowEntryView showEntryView)
        {
            _showEntryView = showEntryView;

            _showEntryView.EditEntryClick += ShowEntryViewOnEditEntryClick;
            _showEntryView.SaveEntryClick += ShowEntryViewOnSaveEntryClick;
        }

        private static void ShowEntryViewOnSaveEntryClick(object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Сохранить запись");
        }

        private void ShowEntryViewOnEditEntryClick(object sender, EventArgs eventArgs)
        {
            var createNewEntryWindow = new CreateNewEntryWindow();
            FlowDocumentEdit.AddDocument(_showEntryView.GetShowEntryViewWindowFlowDocument(), createNewEntryWindow.GetRichTextBoxFlowDocument());
            createNewEntryWindow.Show();
            _showEntryView.CloseShowEntryViewWindow();
        }

        private readonly IShowEntryView _showEntryView;
    }
}
