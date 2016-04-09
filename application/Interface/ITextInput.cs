using System.Windows.Documents;

namespace application.Interface
{
    internal interface ITextInput
    {
        void AddTextWindowShow();
        void AddTextWindowClose();
        FlowDocument GetInputText();
        void SetICreateEntry(ICreateEntry createEntry);
    }
}
