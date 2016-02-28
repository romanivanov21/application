using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace application.Model
{
    internal class ModelTest
    {
        public ModelTest()
        {
            _img1 = new Image();
            EntryesList = new List<Entry>();
        }

        public List<Entry> EntryesList { get; private set; }

        public void AddEntry(Entry entry)
        {
            EntryesList.Add(entry);
        }
        public void FillTestData()
        {
            var imgs = new ImageSourceConverter();
            _img1.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"..\\..\\IMG\IMG_0376.JPG"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись1"));
            _img1.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"..\\..\\IMG\IMG_0261.JPG"));
            EntryesList.Add(new Entry("01.02.2016", _img1.Source, "Запись2"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись3"));
            EntryesList.Add(new Entry("10.03.2015", _img1.Source, "Запись4"));
            EntryesList.Add(new Entry("09.03.2015", _img1.Source, "Запись5"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись6"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись7"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись8"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись9"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись10"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись11"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись12"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись13"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись14"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись15"));
            EntryesList.Add(new Entry(DateTime.Now.ToShortDateString(), _img1.Source, "Запись16"));

        }
        public List<Entry> GetEnrtyesByDate(string date)
        {
            return EntryesList.FindAll(x => (x.Date == date));
        }
        public List<Entry> GetThreeLastEntryes()
        {
            var res = new List<Entry>();
            var lastIndex = EntryesList.Count;
            res.Add(EntryesList[lastIndex - 3]);
            res.Add(EntryesList[lastIndex - 2]);
            res.Add(EntryesList[lastIndex - 1]);
            return res;
        }

        readonly Image _img1;
    }
}
