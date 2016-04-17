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
            _createEntry.AddNewImage += CreateEntryOnAddNewImage;
            _createEntry.AddNewText += CreateEntryOnAddNewText;
        }

        public void CreateEntryOnAddNewText(object sender, EventArgs eventArgs)
        {
            var addTextWindow = new AddTextWindows(_createEntry.GetDocument());
            addTextWindow.Show();
            addTextWindow.SetICreateEntry(_createEntry);
        }

        private void CreateEntryOnAddNewImage(object sender, EventArgs eventArgs)
        {
            var addImgWindow = new AddImgWindow(_createEntry);
            addImgWindow.Show();
        }

        private readonly ICreateEntry _createEntry;
    }
}
