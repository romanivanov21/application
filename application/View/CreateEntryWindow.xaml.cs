using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using application.Controller;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для CreateEntryWindow.xaml
    /// </summary>
    public partial class CreateEntryWindow : ICreateEntry
    {
        public CreateEntryWindow()
        {
            InitializeComponent();
            _createEntryController = new CreateEntryController(this);
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            if (AddNewImage != null)
            {
                AddNewImage(sender, e);
            }
        }

        private void AddText_Click(object sender, RoutedEventArgs e)
        {
            if (AddNewText != null)
            {
                AddNewText(sender, e);
            }
        }

        public FlowDocument GetDocument()
        {
            return EntryViewer.Document;
        }
        
        public Grid GetCreateEntryesGrid()
        {
            return CreateEntryGrid;
        }

        public void SetEntryImage(Image img)
        {
            var bitmapImageBitmapSource = new BitmapImage();
            bitmapImageBitmapSource.BeginInit();
            bitmapImageBitmapSource.UriSource = new Uri("@..\\..\\IMG\\IMG_0261.JPG");
            bitmapImageBitmapSource.EndInit();
            //BlockUIContainer blockUiContainer = new BlockUIContainer(bitmapImageBitmapSource);
            //CreatEntryViewer.Blocks.Add(bitmapImageBitmapSource);
        }

        public void SetEntryViewer(FlowDocument flowDocument)
        {
            EntryViewer.Document = flowDocument;
            /*CreatEntryViewer.Blocks.Clear();
            var blocList = flowDocument.Blocks.ToList();
            foreach (var item in blocList)
            {
                CreatEntryViewer.Blocks.Add(item);
            }*/
        }

        public event EventHandler AddNewImage;

        public event EventHandler AddNewText;

        private CreateEntryController _createEntryController;
    }
}
