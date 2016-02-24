using System;
using System.Windows;
using System.Windows.Controls;
using application.Interface;

namespace application.View
{
    public struct ButtonsLayout
    {
        public bool[] ButtonActives;
        public string[] ButtonContents;
        public ButtonPosition[] ButtonPositions;
        public HorizontalAlignment[] ButtonAlignments;
    }

    public struct ButtonPosition
    {
        public int Colum;
        public int Row;
    }

    public class NavigationLayout : IViewNavButtons
    {
        public NavigationLayout()
        {
            _buttons = new Button[ButtonCount];
            for (var i = 0; i < ButtonCount; i++)
            {
                _buttons[i] = new Button() { Margin = new Thickness(5) };
            }
            _buttons[0].Click += NavigationButtonPrevius_Clik;
            _buttons[1].Click += NavigationButtonOne_Clik;
            _buttons[2].Click += NavigationButtonTwo_Clik;
            _buttons[3].Click += NavigationButtonThree_Clik;
            _buttons[4].Click += NavigationButtonFour_Clik;
            _buttons[5].Click += NavigationButtonNext_Clik;
        }

        private void NavigationButtonPrevius_Clik(object sender, RoutedEventArgs e)
        {
            if (PrevClick != null)
            {
                PrevClick(sender, e);
            }
        }

        private void NavigationButtonOne_Clik(object sender, RoutedEventArgs e)
        {
            if (OneClick != null)
            {
                OneClick(sender, e);
            }
        }

        private void NavigationButtonTwo_Clik(object sender, RoutedEventArgs e)
        {
            if (TwoClick != null)
            {
                TwoClick(sender, e);
            }
        }

        private void NavigationButtonThree_Clik(object sender, RoutedEventArgs e)
        {
            if (ThreClick != null)
            {
                ThreClick(sender, e);
            }
        }

        private void NavigationButtonFour_Clik(object sender, RoutedEventArgs e)
        {
            if (FourClick != null)
            {
                FourClick(sender, e);
            }
        }

        private void NavigationButtonNext_Clik(object sender, RoutedEventArgs e)
        {
            if (NextClick != null)
            {
                NextClick(sender, e);
            }
        }

        public void DrowButtons(ButtonsLayout buttonsLayout)
        {
            for (var i = 0; i < ButtonCount; i++)
            {
                if (!buttonsLayout.ButtonActives[i]) continue;
                _buttons[i].Content = buttonsLayout.ButtonContents[i];
                ListViewGrid.Children.Add(_buttons[i]);
                Grid.SetColumn(_buttons[i], buttonsLayout.ButtonPositions[i].Colum);
                Grid.SetRow(_buttons[i], buttonsLayout.ButtonPositions[i].Row);

            }
        }

#region реализация IViewNavButtons

        public event EventHandler PrevClick;

        public event EventHandler OneClick;

        public event EventHandler TwoClick;

        public event EventHandler ThreClick;

        public event EventHandler FourClick;

        public event EventHandler NextClick;

#endregion

        public Grid ListViewGrid { get; set; }

        //Количество новигационных конопок
        public static int ButtonCount = 6;

        private readonly Button[] _buttons;
    }
}
