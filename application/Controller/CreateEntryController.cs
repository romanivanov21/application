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
            _addImage = new AddImage();

            createEntry.AddNewImage += CreateEntryOnAddNewImage;
            createEntry.AddNewText += CreateEntryOnAddNewText;
        }

        private static void CreateEntryOnAddNewText(object sender, EventArgs eventArgs)
        {
            /*tb = new TextBlock { Width = 130, Height = 30, TextAlignment = TextAlignment.Center, Text = "123" };
            Grid.SetRow(tb, 0);
            Grid.SetColumn(tb, 1);
            _createEntry.GetCreateEntryesGrid().Children.Add(tb);*/
            var addText = new AddTextWindows();
            addText.Show();
        }

        private static void CreateEntryOnAddNewImage(object sender, EventArgs eventArgs)
        {
            var addImg = new AddImgWindow();
            addImg.Show();
        }

        //Point p;
        //TextBlock tb;

        private readonly ICreateEntry _createEntry;
        private readonly AddImage _addImage;
    }
}
