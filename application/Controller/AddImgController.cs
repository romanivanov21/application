using System;
using System.Windows;
using System.Windows.Media.Imaging;
using application.Common;
using application.Interface;

namespace application.Controller
{
    internal class AddImgController
    {
        public AddImgController(IAddImg addImg)
        {
            _addImg = addImg;

            _addImg.AddImgButtonClick += AddImgOnAddImgButtonClick;
            _addImg.ImgLoadingButtonClick += AddImgOnImgLoadingButtonClick;
            _addImg.CancelButtonClick += AddImgOnCancelButtonClick;
        }

        public void SetImageRichTextBox()
        {
            var richTextBox = _addImg.GetRichTextBoxt();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(_addImg.GetImageAditionalSource().ToString());
            bitmapImage.DecodePixelHeight = 40;
            bitmapImage.DecodePixelWidth = 50;
            bitmapImage.EndInit();
            Clipboard.SetImage(bitmapImage);
            richTextBox.Paste();
            _addImg.AddImgWindowClose();
        }

        private void AddImgOnCancelButtonClick(object sender, EventArgs eventArgs)
        {
            _addImg.AddImgWindowClose();
        }

        private void AddImgOnImgLoadingButtonClick(object sender, EventArgs eventArgs)
        {
            _addImg.SetAtitionalImageSourcePath(AddImage.GetImageSourcePatch());
        }

        private void AddImgOnAddImgButtonClick(object sender, EventArgs eventArgs)
        {
            SetImageRichTextBox();
        }

        private readonly IAddImg _addImg;
    }
}
