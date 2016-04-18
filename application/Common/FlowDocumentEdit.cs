using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace application.Common
{
    internal static class FlowDocumentEdit
    {
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
    }
}
