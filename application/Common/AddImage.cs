﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace application.Common
{
    public static class AddImage
    {
        public static string GetImageSourcePatch()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image files (*.JPG)|*.JPG|All files (*.*)|*.*"
            };
            var result = "";
            if (openFileDialog.ShowDialog() == true)
            {
                result = openFileDialog.FileName;
            }
            return result;
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

        public static string OpenImageSource { get; set; }
    }
}
