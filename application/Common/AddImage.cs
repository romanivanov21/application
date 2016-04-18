using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace application.Controller
{
    public class AddImage
    {
        public AddImage()
        {
            ImagePath = "";
            _openFileDialog = new OpenFileDialog
            {
                Multiselect = false, 
                Filter = "Image files (*.JPG)|*.JPG|All files (*.*)|*.*"
            };
        }

        public void GetImagePath()
        {
            if (_openFileDialog.ShowDialog() == true)
            {
                ImagePath = _openFileDialog.FileName;
            }
        }
        public static Bitmap ToWinFormsBitmap(BitmapSource bitmapsource)
        {
            using (var stream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(stream);

                using (var tempBitmap = new Bitmap(stream))
                {
                    // According to MSDN, one "must keep the stream open for the lifetime of the Bitmap."
                    // So we return a copy of the new bitmap, allowing us to dispose both the bitmap and the stream.
                    return new Bitmap(tempBitmap);
                }
            }
        }

        public static BitmapSource ToWpfBitmap(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);

                stream.Position = 0;
                var result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        public string ImagePath { get; private set; }

        private readonly OpenFileDialog _openFileDialog;
    }
}
