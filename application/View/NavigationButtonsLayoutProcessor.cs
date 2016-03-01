using System.Collections;
using System.Diagnostics;
using System.Windows;

namespace application.View
{
    public class NavigationButtonsLayoutProcessor
    {
        public NavigationButtonsLayoutProcessor()
        {
            _navigationButtons = new ButtonsLayout()
            {
                ButtonActives = new BitArray(NavigationButtonsDrow.ButtonCount),
                ButtonPositions = new ButtonPosition[NavigationButtonsDrow.ButtonCount],
                ButtonContents = new string[NavigationButtonsDrow.ButtonCount],
                ButtonAlignments = new HorizontalAlignment[NavigationButtonsDrow.ButtonCount],
                ButtonEnabeled = new BitArray(NavigationButtonsDrow.ButtonCount),
            };
        }

        private void SetButtonsActives()
        {
            //Все записи помещаются в одну страницу (число записей не превышает 3), то все кнопки не активны
            if (PageCount == 0 || PageCount == 1)
            {
                for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
                {
                    _navigationButtons.ButtonActives[i] = false;
                }
            }
            //всего 2 страницы, то активные кнопки навигации 1 - 4
            else if (PageCount == 2)
            {
                for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
                {
                    if (i >= 1 && i <= 4)
                    {
                        _navigationButtons.ButtonActives[i] = true;
                    }
                    else
                    {
                        _navigationButtons.ButtonActives[i] = false;
                    }
                }
            }
            //всего 3 страницы, то активны кноаки навигации с 0 по 4
            else if (PageCount == 3)
            {
                for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
                {
                    if ( i >= 0 && i <= 4)
                    {
                        _navigationButtons.ButtonActives[i] = true;
                    }
                    else
                    {
                        _navigationButtons.ButtonActives[i] = false;
                    }
                }
            }
            //число страниц больше либо равно 4, то все кнопки навигации активны
            else if (PageCount >= 4)
            {
                for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
                    _navigationButtons.ButtonActives[i] = true;
            }
        }

        private void SetButtonAlignments()
        {
            for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
            {
                _navigationButtons.ButtonAlignments[i] = HorizontalAlignment.Center;
            }
            _navigationButtons.ButtonAlignments[0] = HorizontalAlignment.Right;
            _navigationButtons.ButtonAlignments[5] = HorizontalAlignment.Left;
        }

        private void SetButtonEnabeles()
        {
            for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
            {
                _navigationButtons.ButtonEnabeled[i] = true;
            }

            if (PageCount == 2)
            {
                if (1 == CurrentPageIndex)
                {
                    _navigationButtons.ButtonEnabeled[1] = false;
                }
                if (PageCount == CurrentPageIndex) 
                {
                    _navigationButtons.ButtonEnabeled[4] = false;
                }
            }
            else if (PageCount == 3)
            {
                if (CurrentPageIndex == 1)
                {
                    _navigationButtons.ButtonEnabeled[0] = false;
                }
                if (PageCount == CurrentPageIndex)
                {
                    _navigationButtons.ButtonEnabeled[4] = false;
                }
            }
            else if (PageCount == 4)
            {
                if (CurrentPageIndex == 1)
                {
                    _navigationButtons.ButtonEnabeled[0] = false;
                }
                if (PageCount == CurrentPageIndex)
                {
                    _navigationButtons.ButtonEnabeled[5] = false;
                }
            }
            else if (PageCount > 4)
            {
                if (_navigationButtons.ButtonContents[1] == PageButtonContent.One)
                {
                    _navigationButtons.ButtonEnabeled[0] = false;
                }
                if (PageCount == CurrentPageIndex)
                {
                    _navigationButtons.ButtonEnabeled[5] = false;
                }
                if (_navigationButtons.ButtonContents[3] == PageButtonContent.Poins)
                {
                    _navigationButtons.ButtonEnabeled[3] = false;
                }
            }
        }

        private void SetButtonContents()
        {
            if (PageCount != 1)
            {
                if ((PageCount == 2) && ((CurrentPageIndex == 1) || (CurrentPageIndex == 2)))
                {
                    _navigationButtons.ButtonContents[1] = PageButtonContent.Previus;
                    _navigationButtons.ButtonContents[2] = PageButtonContent.One;
                    _navigationButtons.ButtonContents[3] = PageButtonContent.Two;
                    _navigationButtons.ButtonContents[4] = PageButtonContent.Next;
                }
                else if ((PageCount == 3) &&
                         ((CurrentPageIndex == 1) || (CurrentPageIndex == 2) || (CurrentPageIndex == 3)))
                {
                    _navigationButtons.ButtonContents[0] = PageButtonContent.Previus;
                    _navigationButtons.ButtonContents[1] = PageButtonContent.One;
                    _navigationButtons.ButtonContents[2] = PageButtonContent.Two;
                    _navigationButtons.ButtonContents[3] = PageButtonContent.Three;
                    _navigationButtons.ButtonContents[4] = PageButtonContent.Next;
                }
                else if ((PageCount == 4)
                         &&
                         ((CurrentPageIndex == 1) || (CurrentPageIndex == 2) || (CurrentPageIndex == 3) ||
                          (CurrentPageIndex == 4)))
                {
                    _navigationButtons.ButtonContents[0] = PageButtonContent.Previus;
                    _navigationButtons.ButtonContents[1] = PageButtonContent.One;
                    _navigationButtons.ButtonContents[2] = PageButtonContent.Two;
                    _navigationButtons.ButtonContents[3] = PageButtonContent.Three;
                    _navigationButtons.ButtonContents[4] = PageButtonContent.Four;
                    _navigationButtons.ButtonContents[5] = PageButtonContent.Next;
                }
                else if (PageCount > 4)
                {
                    _navigationButtons.ButtonContents[0] = PageButtonContent.Previus;
                    if ((PageCount == CurrentPageIndex) || (CurrentPageIndex == PageCount - 1) ||
                        (CurrentPageIndex == PageCount - 2)
                        || (CurrentPageIndex == PageCount - 3))
                    {
                        _navigationButtons.ButtonContents[1] = PageButtonContent.GetButtonContent(PageCount - 3);
                        _navigationButtons.ButtonContents[2] = PageButtonContent.GetButtonContent(PageCount - 2);
                        _navigationButtons.ButtonContents[3] = PageButtonContent.GetButtonContent(PageCount - 1);
                        _navigationButtons.ButtonContents[4] = PageButtonContent.GetButtonContent(PageCount);
                    }
                    else
                    {
                        _navigationButtons.ButtonContents[1] = PageButtonContent.GetButtonContent(CurrentPageIndex);
                        _navigationButtons.ButtonContents[2] =
                            PageButtonContent.GetButtonContent(CurrentPageIndex + 1);
                        _navigationButtons.ButtonContents[3] = PageButtonContent.Poins;
                        _navigationButtons.ButtonContents[4] = PageButtonContent.GetButtonContent(PageCount);
                    }
                    _navigationButtons.ButtonContents[5] = PageButtonContent.Next;
                }
            }
        }

        public void SetButtonsPosition()
        {
            for (var i = 0; i < NavigationButtonsDrow.ButtonCount; i++)
            {
                _navigationButtons.ButtonPositions[i].Row = 0;
                _navigationButtons.ButtonPositions[i].Colum = i + 1;
            }
        }

        public ButtonsLayout GetButtonsLayout()
        {
            SetButtonsActives();
            SetButtonContents();
            SetButtonEnabeles();
            SetButtonAlignments();
            SetButtonsPosition();
            return _navigationButtons;
        }

        public int GetButtonContentIndex(int i)
        {
            Debug.Assert((i >= 0) && (i <= 6));
            return PageButtonContent.GetButtonIndex(_navigationButtons.ButtonContents[i]);
        }

        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }

        private ButtonsLayout _navigationButtons;
    }
}
