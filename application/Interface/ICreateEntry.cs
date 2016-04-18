using System;
using System.Windows.Documents;

namespace application.Interface
{
    public interface ICreateEntry
    {
        FlowDocument GetRichTextBoxFlowDocument();
        void CloseCreateNewEntryWindow();

        event EventHandler ShowNewEntryButtonClick;
    }
}
