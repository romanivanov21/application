using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

        public Grid GetCreateEntryesGrid()
        {
            return CreateEntryGrid;
        }

        public void SetEntryViewer(FlowDocument flowDocument)
        {
            var blocList = flowDocument.Blocks.ToList();
            foreach (var item in blocList)
            {
                CreatEntryViewer.Blocks.Add(item);
            }
        }

        public event EventHandler AddNewImage;

        public event EventHandler AddNewText;

        private CreateEntryController _createEntryController;

    }
}
