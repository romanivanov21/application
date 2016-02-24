using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using application.Interface;
using application.Model;

namespace application.View
{
    public struct PageButtonContent
    {
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

    public class ViewEntryes
    {
        public ViewEntryes()
        {
            ShowListView = new ListView();

            _buttonsLayout = new ButtonsLayout()
            {
                ButtonActives = new bool[NavigationLayout.ButtonCount],
                ButtonPositions = new ButtonPosition[NavigationLayout.ButtonCount],
                ButtonContents = new string[NavigationLayout.ButtonCount],
                ButtonAlignments = new HorizontalAlignment[NavigationLayout.ButtonCount]
            };

            _currentPageIndex = 1;

            for (var i = 0; i < NavigationLayout.ButtonCount; i++)
            {
                _buttonsLayout.ButtonPositions[i].Row = 0;
                _buttonsLayout.ButtonPositions[i].Colum = i;
            }

            _layout = new bool[NavigationLayout.ButtonCount];
            _content = new string[NavigationLayout.ButtonCount];

            _navigationLayout = new NavigationLayout();
            _pageCount = GetPagesCount(1);

            viewNavButtons_ = _navigationLayout;
            viewNavButtons_.FourClick += ViewNavButtonsOnFourClick;
            viewNavButtons_.NextClick += ViewNavButtonsOnNextClick;
            viewNavButtons_.OneClick += ViewNavButtonsOnOneClick;
            viewNavButtons_.PrevClick += ViewNavButtonsOnPrevClick;
            viewNavButtons_.ThreClick += ViewNavButtonsOnThreClick;
            viewNavButtons_.TwoClick += ViewNavButtonsOnTwoClick;
        }

        public void Drow()
        {
            var content = new string[NavigationLayout.ButtonCount];

            _navigationLayout.ListViewGrid = NavigationGrid;
            _pageCount = GetPagesCount(MainEntrys.Count);
            
            SetLayout(_layout, _pageCount);
            SetContent(content, _pageCount);
            
            Inizialize(_layout, content);
            _navigationLayout.DrowButtons(_buttonsLayout);
            ShowListView.ItemsSource = GetShowList();
            ShowListView.Items.Refresh();
        }
        
        public ListView ShowListView { get; set; }

        public Grid NavigationGrid { get; set; }

        public List<Entry> MainEntrys { get; set; }

        private IEnumerable<Entry> GetShowList()
        {
            var indexFirst = 0;
            var indexLast = 0;
            var list = new List<Entry>(3);
            int pageIndex = 1;

            while ((indexLast < MainEntrys.Count) && (indexLast != 3))
            {
                ++indexLast;
            }

            for (int i = indexLast; (pageIndex != _currentPageIndex) && (indexLast < MainEntrys.Count); i++)
            {
                if ((indexLast - indexFirst) == 3)
                {
                    indexFirst = indexLast;
                    pageIndex++;
                }
                indexLast++;
            }

            for (var i = indexFirst; i <  indexLast; i++)
            {
                list.Add(new Entry(MainEntrys[i].Date, MainEntrys[i].ImgSource, MainEntrys[i].Title));
            }
            return list;
        }

        private void ViewNavButtonsOnPrevClick(object sender, EventArgs eventArgs)
        {

        }

        private void ViewNavButtonsOnOneClick(object sender, EventArgs eventArgs)
        {

        }

        private void ViewNavButtonsOnTwoClick(object sender, EventArgs eventArgs)
        {

        }

        private void ViewNavButtonsOnThreClick(object sender, EventArgs eventArgs)
        {

        }

        private void ViewNavButtonsOnFourClick(object sender, EventArgs eventArgs)
        {

        }

        private void ViewNavButtonsOnNextClick(object sender, EventArgs eventArgs)
        {

        }

        private static void SetContent(IList<string> content, int index)
        {
            if (index == 2)
            {
                content[1] = PageButtonContent.Previus;
                content[2] = PageButtonContent.One;
                content[3] = PageButtonContent.Two;
                content[4] = PageButtonContent.Next;
            }
            else if (index == 3)
            {
                content[0] = PageButtonContent.Previus;
                content[1] = PageButtonContent.One;
                content[2] = PageButtonContent.Two;
                content[3] = PageButtonContent.Three;
                content[4] = PageButtonContent.Next;
            }
            else if (index == 4)
            {
                content[0] = PageButtonContent.Previus;
                content[1] = PageButtonContent.One;
                content[2] = PageButtonContent.Two;
                content[3] = PageButtonContent.Three;
                content[4] = PageButtonContent.Four;
                content[5] = PageButtonContent.Next;
            }
            else if (index > 4)
            {
                content[0] = PageButtonContent.Previus;
                content[1] = PageButtonContent.GetButtonContent(_currentPageIndex);
                content[2] = PageButtonContent.GetButtonContent(_currentPageIndex + 1);
                content[3] = PageButtonContent.Poins;
                content[4] = PageButtonContent.GetButtonContent(index);
                content[5] = PageButtonContent.Next;
            }
        }

        private static void SetLayout(IList<bool> layout, int index)
        {
            if (index == 1)
            {
                for (var i = 0; i < NavigationLayout.ButtonCount; i++)
                {
                    layout[i] = false;
                }
            }
            else if (index == 2)
            {
                for (var i = 0; i < NavigationLayout.ButtonCount; i++)
                {
                    if ((i == 1) || (i == 2) || (i == 3) || (i == 4))
                    {
                        layout[i] = true;
                    }
                }
            }
            else if (index == 3)
            {
                for (var i = 0; i < NavigationLayout.ButtonCount; i++)
                {
                    if ((i == 0) || (i == 1) || (i == 2) || (i == 3) || (i == 4))
                    {
                        layout[i] = true;
                    }
                }
            }
            else if (index >= 4)
            {
                for (var i = 0; i < NavigationLayout.ButtonCount; i++)
                    layout[i] = true;
            }
        }

        private void Inizialize(bool[] layout, string [] content)
        {
            _buttonsLayout.ButtonActives = layout;
            _buttonsLayout.ButtonContents = content;
            for (var i = 0; i < NavigationLayout.ButtonCount; i++)
            {
                _buttonsLayout.ButtonPositions[i].Row = 2;
                _buttonsLayout.ButtonPositions[i].Colum = i;
                if (i == 0)
                {
                    _buttonsLayout.ButtonAlignments[i] = HorizontalAlignment.Right;
                    _buttonsLayout.ButtonContents[i] = content[i];
                }
                else if (i == 5)
                {
                    _buttonsLayout.ButtonAlignments[i] = HorizontalAlignment.Left;
                    _buttonsLayout.ButtonContents[i] = content[i];

                }
                else
                {
                    _buttonsLayout.ButtonAlignments[i] = HorizontalAlignment.Center;
                    _buttonsLayout.ButtonContents[i] = content[i];
                }
            }
        }

        //получить число страниц
        private static int GetPagesCount(int count)
        {
            var res = 0;
            double doubleTemp = (double)count / PageItemCount;
            if (doubleTemp == (int)doubleTemp)
            {
                res = (int)doubleTemp;
            }
            else
            {
                res = (int)doubleTemp;
                ++res;
            }
            return res;
        }

        private bool[] _layout;

        private string[] _content;

        public static double PageItemCount = 3.0;

        private readonly IViewNavButtons viewNavButtons_;

        private readonly NavigationLayout _navigationLayout;

        private ButtonsLayout _buttonsLayout;

        //число страниц
        private int _pageCount;

        //текущая страница
        private static int _currentPageIndex;

    }
}
