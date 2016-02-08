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
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись2"));
            entryes_.Add(new Entry(DateTime.Now.ToShortDateString(), img1_.Source, "Запись3"));
        }
        Image img1_;
        private List<Entry> entryes_;
    }
}
