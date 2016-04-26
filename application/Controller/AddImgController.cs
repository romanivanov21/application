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

            _addImg.HeightIncrementButtonClick += AddImgOnHeightIncrementButtonClick;
            _addImg.HeightDecrementButtonClick += AddImgOnHeightDecrementButtonClick;

            _addImg.WidthDecrementButtonClick += AddImgOnWidthDecrementButtonClick;
            _addImg.WidthIncrementButtonClick += AddImgOnWidthIncrementButtonClick;

            _addImg.ImageAditionalHeightSliperValueChanged += AddImgOnImageAditionalHeightSliperValueChanged;
            _addImg.ImageAditionalWidthSliperValueChanged += AddImgOnImageAditionalWidthSliperValueChanged;

            _addImg.AddImgButtonClick += AddImgOnAddImgButtonClick;
            _addImg.ImgLoadingButtonClick += AddImgOnImgLoadingButtonClick;
            
            _addImg.CancelButtonClick += AddImgOnCancelButtonClick;
        }

        private void AddImgOnImageAditionalWidthSliperValueChanged(object sender, EventArgs eventArgs)
        {
            //_addImg.SetImageAditionalHeightSliperValue(_addImg.GetImageAditionalHeight());
        }

        private void AddImgOnImageAditionalHeightSliperValueChanged(object sender, EventArgs eventArgs)
        {
            //_addImg.SetImageAditionalWidthSliperValue(_addImg.GetImageAditionalWidth());
        }

        public void SetImageRichTextBox()
        {
            var richTextBox = _addImg.GetRichTextBoxt();
            var bitmapImage = new BitmapImage();
            if (_addImg.IsImageAditionalLoaded())
            {
                var uri = _addImg.GetImageAditionalSource().ToString();
                if (uri != "")
                {
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(uri);
                    bitmapImage.DecodePixelHeight = _addImg.GetHeightValueFromTextBox();
                    bitmapImage.DecodePixelWidth = _addImg.GetWidthValueFromTextBox();
                    bitmapImage.EndInit();
                    Clipboard.SetImage(bitmapImage);
                    richTextBox.Paste();
                }
            }
            _addImg.AddImgWindowClose();
        }

        private void AddImgOnHeightIncrementButtonClick(object sender, EventArgs eventArgs)
        {
            var value = _addImg.GetImageAditionalHeight();
            value++;
            _addImg.SetHeightValueToTextBox(value);
            _addImg.SetImageAditionalHeigth(value);
        }

        private void AddImgOnHeightDecrementButtonClick(object sender, EventArgs eventArgs)
        {

        }

        private void AddImgOnWidthDecrementButtonClick(object sender, EventArgs eventArgs)
        {

        }

        private void AddImgOnWidthIncrementButtonClick(object sender, EventArgs eventArgs)
        {

        }

        private void AddImgOnCancelButtonClick(object sender, EventArgs eventArgs)
        {
            _addImg.AddImgWindowClose();
        }

        private void AddImgOnImgLoadingButtonClick(object sender, EventArgs eventArgs)
        {
            _addImg.SetAtitionalImageSourcePath(AddImage.GetImageSourcePatch());
            if (_addImg.IsImageAditionalLoaded())
            {
                var width = _addImg.GetImageAditionalWidth();
                var height = _addImg.GetImageAditionalHeight();
                _addImg.SetWidthValueToTextBox(width);
                _addImg.SetHeightValueToTextBox(height);
                _addImg.SetImageAditionalWidthSliperValue(width);
                _addImg.SetImageAditionalHeightSliperValue(height);
                MessageBox.Show("Изображение загружено");
            }
        }

        private void AddImgOnAddImgButtonClick(object sender, EventArgs eventArgs)
        {
            SetImageRichTextBox();
        }

        private readonly IAddImg _addImg;
    }
}
