using System;
using System.Collections;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using application.Interface;

namespace application.View
{
    public struct ButtonsLayout
    {
        /// <summary>
        /// Массив битов, число элеменов равна количеству кнопок, 
        /// если элемент массива равна 1, то кнопка рисуется 
        /// </summary>
        public BitArray ButtonActives;
        /// <summary>
        /// Массив битов, число элементов равна количеству кнопок,
        /// если элемент массива равна 1, то кнопка активна
        /// </summary>
        public BitArray ButtonEnabeled;
        /// <summary>
        /// Массив строк, содержит названия кнопок
        /// </summary>
        public string[] ButtonContents;
        public ButtonPosition[] ButtonPositions;
        public HorizontalAlignment[] ButtonAlignments;
    }

    public struct PageButtonContent
    {
        public static int GetButtonIndex(string content)
        {
            //Debug.Assert(content[0] == ' ' && content[2] == ' ');
            if (content != Poins)
            {
                return int.Parse(content[1].ToString());
            }
            return -1;
        }

        public static string GetButtonContent(int i)
        {
            return " " + i.ToString() + " ";
        }

        public static readonly string Next = " Далее ";
        public static readonly string One = " 1 ";
        public static readonly string Two = " 2 ";
        public static readonly string Three = " 3 ";
        public static readonly string Four = " 4 ";
        public static readonly string Poins = " ... ";
        public static readonly string Previus = " Назад ";
    }

    public struct ButtonPosition
    {
        public int Colum;
        public int Row;
    }

    public class NavigationButtonsDrow : INavigationButtonsClick
    {
        public NavigationButtonsDrow()
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
        
        /// <summary>
        /// Рисует кнопки с заданными параметрами
        /// </summary>
        /// <param name="buttonsLayout"> Парамитры кнопки </param>

        public void DrowButtons(ButtonsLayout buttonsLayout)
        {
            ButtonsGrid.Children.Clear();
            for (var i = 0; i < buttonsLayout.ButtonActives.Length; i++)
            {
                if (buttonsLayout.ButtonActives.Get(i))
                {
                    _buttons[i].Content = buttonsLayout.ButtonContents[i];
                    if (ButtonsGrid != null)
                    {
                        ButtonsGrid.Children.Add(_buttons[i]);
                        Grid.SetColumn(_buttons[i], buttonsLayout.ButtonPositions[i].Colum);
                        Grid.SetRow(_buttons[i], buttonsLayout.ButtonPositions[i].Row);
                    }
                }
                _buttons[i].IsEnabled = buttonsLayout.ButtonEnabeled.Get(i);
            }
        }

        public void MarkButtonClear()
        {
            for (var i = 0; i < ButtonCount; i++)
            {
                _buttons[i].Background = new SolidColorBrush { Color = Color.FromArgb(255, 255, 255, 255) };
            }
        }

        public void MarkButton(int i)
        {
            _buttons[i].Background = new SolidColorBrush {Color = Color.FromArgb(255, 101, 173, 241)};
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

#region реализация IViewNavButtons

        public event EventHandler PrevClick;

        public event EventHandler OneClick;

        public event EventHandler TwoClick;

        public event EventHandler ThreClick;

        public event EventHandler FourClick;

        public event EventHandler NextClick;

#endregion

        //Количество новигационных конопок
        public static int ButtonCount = 6;

        public Grid ButtonsGrid { get; set; }

        private readonly Button[] _buttons;
    }
}
