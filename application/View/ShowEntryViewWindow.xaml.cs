using System;
using System.Windows.Documents;
using application.Common;
using application.Controller;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для CreateEntryWindow.xaml
    /// </summary>
    public partial class ShowEntryViewWindow : IShowEntryView
    {
        public ShowEntryViewWindow()
        {
            InitializeComponent();
            _controller = new ShowEntryViewController(this);
        }

        public void SetRichTextBoxDocument(FlowDocument richTextBoxDocument)
        {
            FlowDocumentEdit.AddDocument(richTextBoxDocument, EntryViewer.Document);
        }

        private void SaveEntry_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void EditEntry_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (EditEntryClick != null)
            {
                EditEntryClick(sender, e);
            }
        }

        public FlowDocument GetShowEntryViewWindowFlowDocument()
        {
            return EntryViewer.Document;
        }

        public void CloseShowEntryViewWindow()
        {
            Close();
        }

        public event EventHandler EditEntryClick;
        public event EventHandler SaveEntryClick;

        private ShowEntryViewController _controller;
    }
}
