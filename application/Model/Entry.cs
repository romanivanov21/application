using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace application.Model
{
    public class Entry
    {
        public Entry(string date, ImageSource imgSource, string title)
        {
            date_ = date;
            imgSource_ = imgSource;
            title_ = title;
        }

        public string date_ { get; set; }
        public ImageSource imgSource_ { get; set; }
        public string title_ { get; set; }
    }
}
