using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

        public ViewEntryes(ListView listView, Grid navigationGrid, List<Entry> mainEntryes)
        {
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
            _pageCount = GetPagesCount(mainEntryes.Count);
            _pages = new Page( listView, navigationGrid );
            _currentEntryesList = mainEntryes;
        }

        public void Drow()
        {
            var layout = new bool[NavigationLayout.ButtonCount];
            var content = new string[NavigationLayout.ButtonCount];

            SetLayout(layout, _pageCount);
            SetContent(content, _pageCount);
            
            Inizialize(layout, content);
            _pages.Drow(_buttonsLayout, _currentEntryesList);
        }

        private void SetContent(IList<string> content, int index)
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

        private ButtonsLayout _buttonsLayout;
        //число страниц
        private readonly int _pageCount;
        //текущая страница
        private readonly int _currentPageIndex;
        public static double PageItemCount = 3.0;
        private readonly Page _pages;
        private readonly List<Entry> _currentEntryesList;
    }
}
