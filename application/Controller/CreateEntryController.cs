using System;
using application.Interface;
using application.View;

namespace application.Controller
{
    internal class CreateEntryController
    {
        public CreateEntryController(ICreateEntry createEntry)
        {
            _createEntry = createEntry;
            _createEntry.ShowNewEntryButtonClick += CreateEntryOnShowNewEntryButtonClick;
        }

        private void CreateEntryOnShowNewEntryButtonClick(object sender, EventArgs eventArgs)
        {
            var showEntryViewWindow = new ShowEntryViewWindow();
            showEntryViewWindow.SetRichTextBoxDocument(_createEntry.GetRichTextBoxFlowDocument());
            showEntryViewWindow.Show();
            _createEntry.CloseCreateNewEntryWindow();
        }

        private readonly ICreateEntry _createEntry;
    }
}
