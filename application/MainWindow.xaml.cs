using application.Controller;
using application.Interface;
using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView, IViewFind
    {
        public MainWindow()
        {
            InitializeComponent();
            conteroller_ = new application.Controller.Controller(this, this);
        }

        #region IView

        #region Методы

        public ListView GetMainListView()
        {
            return mainListVliew_;
        }

        public void WindowInit(List<Entry> mainListView)
        {
            mainListVliew_.ItemsSource = mainListView;
            mainListVliew_.Items.Refresh();
        }

        #endregion

        #region События

        private void mainListVliew__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainListVliewSelectionChanged != null)
            {
                mainListVliewSelectionChanged(sender, e);
            }
        }

        #endregion

        private void DateFindRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (dateFindRadioChecked != null)
            {
                dateFindRadioChecked(sender, e);
            }
        }

        #endregion

        #region IViewFind

        #region Методы

        public void FindBoxSetText(string text)
        {
            FindBoxs.Text = text;
        }

        #endregion

        #region События 

        private void DescriptionFindRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (descriptionFindRadioChecked != null)
            {
                descriptionFindRadioChecked(sender, e);
            }
        }

        #endregion

        private void FindBoxs_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (findBoxsGotKeyboardFocus != null)
            {
                findBoxsGotKeyboardFocus(sender, e);
            }
        }

        #endregion

        public event EventHandler mainListVliewSelectionChanged;

        public event EventHandler dateFindRadioChecked;
        public event EventHandler descriptionFindRadioChecked;
        public event EventHandler findBoxsGotKeyboardFocus;

        private application.Controller.Controller conteroller_;
    }
}
