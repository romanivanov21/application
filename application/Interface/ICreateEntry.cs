using System;
using System.Windows.Controls;

namespace application.Interface
{
    internal interface ICreateEntry
    {
        event EventHandler AddNewText;
        event EventHandler AddNewImage;

        Grid GetCreateEntryesGrid();
    }
}
