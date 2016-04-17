using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для AddTextWindows.xaml
    /// </summary>
    public partial class AddTextWindows : ITextInput
    {
        public AddTextWindows(FlowDocument document)
        {
            InitializeComponent();
            _originalDocument = new FlowDocument();
            AddDocument(document, _originalDocument);
            AddDocument(document, InputText.Document);
        }

        private void AddTextButton_Click(object sender, RoutedEventArgs e)
        {
            _originalDocument.Blocks.Clear();
            AddDocument(InputText.Document, _originalDocument);
            Close();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            _createEntry.SetEntryViewer(_originalDocument);
        }

        public static void AddDocument(FlowDocument from, FlowDocument to)
        {
            var range = new TextRange(from.ContentStart, from.ContentEnd);
            var stream = new MemoryStream();
            System.Windows.Markup.XamlWriter.Save(range, stream);
            range.Save(stream, DataFormats.XamlPackage);
            var range2 = new TextRange(to.ContentEnd, to.ContentEnd);
            range2.Load(stream, DataFormats.XamlPackage);
        }

        public static void AddBlock(Block from, FlowDocument to)
        {
            if (from != null)
            {
                var range = new TextRange(from.ContentStart, from.ContentEnd);
                var stream = new MemoryStream();
                System.Windows.Markup.XamlWriter.Save(range, stream);
                range.Save(stream, DataFormats.XamlPackage);
                var textRange2 = new TextRange(to.ContentEnd, to.ContentEnd);
                textRange2.Load(stream, DataFormats.XamlPackage);
            }
        }
        public void SetICreateEntry(ICreateEntry createEntry)
        {
            _createEntry = createEntry;
        }

        bool _isAddButtonClick;
        private readonly FlowDocument _originalDocument;
        private static ICreateEntry _createEntry;
    }
}
