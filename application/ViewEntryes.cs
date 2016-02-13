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

            buttons_.Add(new Button() { Margin = new Thickness(25, 433, 0, 0), Content = "1", Width = 45, Height = 20 });
            mainGrid.Children.Add(buttons_[0]);
            Grid.SetRow(buttons_[0], 1);
            Grid.SetColumn(buttons_[0], 1);

            /*for (int i = 0; i < buttons_.Count; i++)
            {
                buttons_.Add(new Button() { Margin = new Thickness(5), Content = i.ToString() });
                mainGrid.Children.Add(buttons_[i]);
                Grid.SetRow(buttons_[i], 2);
                Grid.SetColumn(buttons_[i], 2);
            }*/
        }

        //получить число страниц
        static public int GetPagesCount(int count)
        {
            int res = 0;
            double doubleTemp = count / 3;
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

        public List<Button> getButtons
        {
            get
            {
                return buttons_;
            }
        }

        public void SetButtonParams(int width, int heidt)
        {
            /*for (int i = 0; i < buttonCount_; i++)
            {
                buttons_[i].Width = width;
                buttons_[i].Height = heidt;
            }*/
        }

        private const uint buttonsCountMax_ = 6; 
        private List<Button> buttons_;
    }
}
