using System;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using application.Controller;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для CreateNewEntryWindow.xaml
    /// </summary>
    public partial class CreateNewEntryWindow : ICreateEntry
    {
        public CreateNewEntryWindow()
        {
            InitializeComponent();
            _controller = new CreateEntryController(this);
        }

        public void CloseCreateNewEntryWindow()
        {
            Close();
        }

        public FlowDocument GetRichTextBoxFlowDocument()
        {
            return RichTextBoxFlowDocument.Document;
        }

        private void ShowNewEntry_Click(object sender, RoutedEventArgs e)
        {
            if (ShowNewEntryButtonClick != null)
            {
                ShowNewEntryButtonClick(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addImg = new AddImgWindow();
            addImg.Show();
        }

        public event EventHandler ShowNewEntryButtonClick;

        private CreateEntryController _controller;
        private static ICreateEntry _createEntry;
    }
}
