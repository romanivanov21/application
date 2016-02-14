using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace application
{
    public class ViewEntryes
    {
        public ViewEntryes()
        {
            buttons_ = new List<Button>();
        }

        public void DrowListViewPage(Grid listViewGrid, int buttonCount)
        {
            if (buttonCount > 1)
            {
                buttons_.Add(new Button() { Margin = new Thickness(10), Content = "  Назад  " });
                listViewGrid.Children.Add(buttons_[0]);
                Grid.SetRow(buttons_[0], 2);
                Grid.SetColumn(buttons_[0], 0);
                buttons_[0].HorizontalAlignment = HorizontalAlignment.Right;

                for (int i = 1; i <= buttonCount; i++)
                {
                    buttons_.Add(new Button() { Margin = new Thickness(10), Content = "  " + i.ToString() + "  " });
                    listViewGrid.Children.Add(buttons_[i]);
                    Grid.SetRow(buttons_[i], 2);
                    Grid.SetColumn(buttons_[i], i);
                    buttons_[i].HorizontalAlignment = HorizontalAlignment.Center;
                }

                buttons_.Add(new Button() { Margin = new Thickness(10), Content = "  Далее  " });
                listViewGrid.Children.Add(buttons_[buttonCount + 1]);
                Grid.SetRow(buttons_[buttonCount + 1], 2);
                Grid.SetColumn(buttons_[buttonCount + 1], 6);
                buttons_[buttonCount + 1].HorizontalAlignment = HorizontalAlignment.Left;
            }
        }

        //получить число страниц
        static public int GetPagesCount(int count)
        {
            int res = 0;
            double doubleTemp = (double)count / 3.0;
            int intTemp = 0;
            if (doubleTemp == (int)doubleTemp)
            {
                intTemp = (int)doubleTemp;
            }
            else
            {
                intTemp = (int)doubleTemp;
                ++intTemp;
            }

            if (intTemp > buttonsCountMax_)
            {
                res = 4;
            }
            else
            {
                res = intTemp;
            }
            return res;
        }

        private const uint buttonsCountMax_ = 4;
        private List<Button> buttons_;
    }
}
