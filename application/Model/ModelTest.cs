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
    class ModelTest
    {
        public ModelTest()
        {
            img1_ = new Image();
            entryes_ = new List<Entry>();
        }

        public List<Entry> EntryesList
        {
            get
            {
                return this.entryes_;
            }
        }
        public void AddEntry(Entry entry)
        {
            entryes_.Add(entry);
        }
        public void FillTestData()
        {
            ImageSourceConverter imgs = new ImageSourceConverter();
            img1_.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"..\\..\\IMG\IMG_0376.JPG"));
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись1"));
            img1_.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"..\\..\\IMG\IMG_0261.JPG"));
            entryes_.Add(new Entry("01.02.2016", img1_.Source, "Запись2"));
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись3"));
            entryes_.Add(new Entry("10.03.2015", img1_.Source, "Запись4"));
            entryes_.Add(new Entry("09.03.2015", img1_.Source, "Запись5"));
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись6"));
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись7"));
        }
        public List<Entry> GetEnrtyesByDate(string date)
        {
            return entryes_.FindAll(x => (x.date_ == date));
        }
        public List<Entry> GetThreeLastEntryes()
        {
            List<Entry> res = new List<Entry>();
            int lastIndex = entryes_.Count;
            res.Add(entryes_[lastIndex - 1]);
            res.Add(entryes_[lastIndex - 2]);
            res.Add(entryes_[lastIndex - 3]);
            return res;
        }

        Image img1_;
        private List<Entry> entryes_;
    }
}
