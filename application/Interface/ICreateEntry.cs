using System;
using System.Windows.Controls;
using System.Windows.Documents;

namespace application.Interface
{
    public interface ICreateEntry
    {
        event EventHandler AddNewText;
        event EventHandler AddNewImage;

        Grid GetCreateEntryesGrid();
        void SetEntryViewer(FlowDocument flowDocument);
    }
}
