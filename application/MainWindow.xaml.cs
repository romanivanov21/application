using application.Interface;
using application.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using application.View;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IView, IViewFind
    {
        public MainWindow()
        {
            InitializeComponent();
            _viewEntryes = new ViewEntryes();
            _conteroller = new Controller.Controller(this, this);
        }

        #region IView

        #region Методы

        public ListView GetMainListView()
        {
            return mainListVliew_;
        }

        public void ListViewUpdate(List<Entry> mainListView)
        {
            _viewEntryes.ShowListView = mainListVliew_;
            _viewEntryes.NavigationGrid = ShowListView;
            _viewEntryes.MainEntrys = mainListView;
            _viewEntryes.Drow();
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
            return MainCalendar.SelectedDate != null ? MainCalendar.SelectedDate.Value.ToShortDateString() : MainCalendar.DisplayDate.ToShortDateString();
        }

        public void FindBoxSetText(string text)
        {
            FindBoxs.Text = "";
            FindBoxs.Text = text;
        }

        public bool isDateFindRadiEnabeled()
        {
            return DateFindRadio.IsChecked != null && DateFindRadio.IsChecked.Value;
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

        private void CareateEntry_Click(object sender, RoutedEventArgs e)
        {
            var createEntryWindow = new CreateEntryWindow();
            createEntryWindow.Show();
        }

        public event EventHandler mainListVliewSelectionChanged;

        public event EventHandler mainCalendarSelectedDatesChanged;
        public event EventHandler dateFindRadioChecked;
        public event EventHandler descriptionFindRadioChecked;
        public event EventHandler findBoxsGotKeyboardFocus;
        public event EventHandler findButtonClick;

        private readonly ViewEntryes _viewEntryes;
        private Controller.Controller _conteroller;
    }
}
