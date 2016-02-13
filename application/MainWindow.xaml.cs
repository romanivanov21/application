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
using System.Windows.Controls.Primitives;
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

        public void ListViewUpdate(List<Entry> mainListView)
        {
            ViewEntryes viewButton;
            if (mainListView.Count <= 3)
            {
                BackPage.IsEnabled = false;
                NextPage.IsEnabled = false;
            }
            else
            {
                viewButton = new ViewEntryes(mainGrid, ViewEntryes.GetPagesCount(mainListView.Count));
                
            }
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

        #endregion

        #region IViewFind

        #region Методы

        public string GetSelectedMainCalendarDate()
        {
            if (MainCalendar.SelectedDate != null)
            {
                return MainCalendar.SelectedDate.Value.ToShortDateString();
            }
            return MainCalendar.DisplayDate.ToShortDateString();
        }

        public void FindBoxSetText(string text)
        {
            FindBoxs.Text = "";
            FindBoxs.Text = text;
        }

        public bool isDateFindRadiEnabeled()
        {
            return DateFindRadio.IsChecked.Value;
        }

        public string GetFindBoxText()
        {
            return FindBoxs.Text;
        }

        #endregion

        #region События 

        private void DateFindRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (dateFindRadioChecked != null)
            {
                dateFindRadioChecked(sender, e);
            }
        }

        private void DescriptionFindRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (descriptionFindRadioChecked != null)
            {
                descriptionFindRadioChecked(sender, e);
            }
        }

        private void FindBoxs_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (findBoxsGotKeyboardFocus != null)
            {
                findBoxsGotKeyboardFocus(sender, e);
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (findButtonClick != null)
            {
                findButtonClick(sender, e);
            }
        }

        private void MainCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainCalendarSelectedDatesChanged != null)
            {
                mainCalendarSelectedDatesChanged(sender, e);
            }
        }

        #endregion

        #endregion

        public event EventHandler mainListVliewSelectionChanged;

        public event EventHandler mainCalendarSelectedDatesChanged;
        public event EventHandler dateFindRadioChecked;
        public event EventHandler descriptionFindRadioChecked;
        public event EventHandler findBoxsGotKeyboardFocus;
        public event EventHandler findButtonClick;

        private application.Controller.Controller conteroller_;

    }
}
