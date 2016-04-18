using System;
using System.Windows.Documents;

namespace application.Interface
{
    internal interface IShowEntryView
    {
        event EventHandler EditEntryClick;
        event EventHandler SaveEntryClick;

        void CloseShowEntryViewWindow();
        void SetRichTextBoxDocument(FlowDocument richTextBoxDocument);
        FlowDocument GetShowEntryViewWindowFlowDocument();

    }
}
