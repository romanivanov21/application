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
            Date = date;
            ImgSource = imgSource;
            Title = title;
        }

        public string Date { get; set; }
        public ImageSource ImgSource { get; set; }
        public string Title { get; set; }
    }
}
