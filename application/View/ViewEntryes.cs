using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using application.Interface;
using application.Model;

namespace application.View
{
    public class ViewEntryes
    {
        public ViewEntryes()
        {
            ShowListView = new ListView();
            
            _navigationButtonsLayoutProcessor = new NavigationButtonsLayoutProcessor();
            _navigationButtons = new NavigationButtonsDrow();
            
            _currentPageIndex = 1;
            _pageCount = GetPagesCount(0);

            _currentButtonIndex = 1;

            INavigationButtonsClick viewNavButtons = _navigationButtons;
            viewNavButtons.FourClick += ViewNavButtonsFourClick;
            viewNavButtons.NextClick += ViewNavButtonsNextClick;
            viewNavButtons.OneClick += ViewNavButtonsOneClick;
            viewNavButtons.PrevClick += ViewNavButtonsPrevClick;
            viewNavButtons.ThreClick += ViewNavButtonsThreClick;
            viewNavButtons.TwoClick += ViewNavButtonsTwoClick;
        }

        public void Drow()
        {
            _pageCount = GetPagesCount(MainEntrys.Count);

            _navigationButtonsLayoutProcessor.PageCount = _pageCount;
            _navigationButtonsLayoutProcessor.CurrentPageIndex = _currentPageIndex;
            _navigationButtons.ButtonsGrid = NavigationGrid;
            _navigationButtons.DrowButtons(_navigationButtonsLayoutProcessor.GetButtonsLayout());
            _navigationButtons.MarkButtonClear();
            _navigationButtons.MarkButton(_currentButtonIndex);

            ShowListView.ItemsSource = GetShowList();
            ShowListView.Items.Refresh();
        }
        
        public ListView ShowListView { get; set; }

        public Grid NavigationGrid { get; set; }

        public List<Entry> MainEntrys { get; set; }

        private IEnumerable<Entry> GetShowList()
        {
            var indexFirst = (_currentPageIndex - 1) * 3;
            var indexLast = 0;
            while ((indexLast < MainEntrys.Count) && (indexLast - indexFirst) < 3)
            {
                indexLast++;
            }
            var list = new List<Entry>(3);

            for (var i = indexFirst; i <  indexLast; i++)
            {
                list.Add(new Entry(MainEntrys[i].Date, MainEntrys[i].ImgSource, MainEntrys[i].Title));
            }
            return list;
        }

        private void ViewNavButtonsPrevClick(object sender, EventArgs eventArgs)
        {
            if (_currentPageIndex > 1)
            {
                _currentPageIndex--;
                if (_currentButtonIndex > 1)
                {
                    _currentButtonIndex--;
                }
                Drow();
            }
        }

        private void ViewNavButtonsOneClick(object sender, EventArgs eventArgs)
        {
            _currentButtonIndex = 1;
            _currentPageIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(_currentButtonIndex);
            Drow();
        }

        private void ViewNavButtonsTwoClick(object sender, EventArgs eventArgs)
        {
            _currentButtonIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(3) == -1 ? 1 : 2;
            _currentPageIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(2);
            Drow();
        }

        private void ViewNavButtonsThreClick(object sender, EventArgs eventArgs)
        {
            _currentButtonIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(3) == -1 ? 1 : 3;
            _currentPageIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(3);
            Drow();
        }

        private void ViewNavButtonsFourClick(object sender, EventArgs eventArgs)
        {
            int contentIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(4);
            if (contentIndex != -1)
            {
                _currentButtonIndex = _navigationButtonsLayoutProcessor.GetButtonContentIndex(3) == -1 ? 1 : 4;
                _currentPageIndex = contentIndex;
                Drow();
            }
        }

        private void ViewNavButtonsNextClick(object sender, EventArgs eventArgs)
        {
            if (_currentPageIndex <= _pageCount)
            {
                _currentPageIndex++;
                if (_navigationButtonsLayoutProcessor.GetButtonContentIndex(3) == -1)
                {
                    _currentButtonIndex = 1;
                }
                else
                {
                    if (_currentButtonIndex < 6)
                    {
                        _currentButtonIndex++;
                    }
                }
            }
            Drow();
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

        public static double PageItemCount = 3.0;

        private readonly NavigationButtonsDrow _navigationButtons;

        private readonly NavigationButtonsLayoutProcessor _navigationButtonsLayoutProcessor;

        private int _currentButtonIndex;
        
        //число страниц
        private int _pageCount;

        //текущая страница
        private int _currentPageIndex;
    }
}
