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
        public ViewEntryes(Grid mainGrid, int buttonCount)
        {
            buttons_ = new List<Button>();

            if (buttonCount > 1)
            {
                buttons_.Add(new Button() { Margin = new Thickness(5), Content = "  Назад  " });
                mainGrid.Children.Add(buttons_[0]);
                Grid.SetRow(buttons_[0], 2);
                Grid.SetColumn(buttons_[0], 0);
                buttons_[0].HorizontalAlignment = HorizontalAlignment.Left;

                for (int i = 1; i <= buttonCount; i++)
                {
                    buttons_.Add(new Button() { Margin = new Thickness(5), Content = i.ToString() });
                    mainGrid.Children.Add(buttons_[i]);
                    Grid.SetRow(buttons_[i], 2);
                    Grid.SetColumn(buttons_[i], i);
                    buttons_[i].HorizontalAlignment = HorizontalAlignment.Center;
                }

                buttons_.Add(new Button() { Margin = new Thickness(5), Content = "  Далее  " });
                mainGrid.Children.Add(buttons_[buttonCount + 1]);
                Grid.SetRow(buttons_[buttonCount + 1], 2);
                Grid.SetColumn(buttons_[buttonCount + 1], 6);
                buttons_[buttonCount + 1].HorizontalAlignment = HorizontalAlignment.Right;
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
                res = 6;
            }
            else
            {
                res = intTemp;
            }
            return res;
        }

        private const uint buttonsCountMax_ = 6; 
        private List<Button> buttons_;
    }
}
