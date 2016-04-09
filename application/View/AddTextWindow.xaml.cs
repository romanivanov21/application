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
        public AddTextWindows()
        {
            InitializeComponent();
            _entry = InputText.Document;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _createEntry.SetEntryViewer(InputText.Document);
            Close();
        }

        public void AddTextWindowShow()
        {
            Show();
        }

        public void AddTextWindowClose()
        {
            Close();
        }

        public FlowDocument GetInputText()
        {
            return _entry;
        }

        public void SetICreateEntry(ICreateEntry createEntry)
        {
            _createEntry = createEntry;
        }

        private static FlowDocument _entry;
        private static ICreateEntry _createEntry;
    }
}
