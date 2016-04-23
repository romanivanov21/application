﻿using System;
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
            _bitmapImage = new BitmapImage();

            _addImg.AddImgButtonClick += AddImgOnAddImgButtonClick;
            _addImg.ImgLoadingButtonClick += AddImgOnImgLoadingButtonClick;
        }

        public void SetImageRichTextBox()
        {
            var richTextBox = _addImg.GetRichTextBoxt();
            Clipboard.SetImage(_bitmapImage);
            richTextBox.Paste();
        }

        private void AddImgOnImgLoadingButtonClick(object sender, EventArgs eventArgs)
        {
            var source = AddImage.GetImageSource();
            if ((source != "") && (source != AddImage.OpenImageSource))
            {
                AddImage.OpenImageSource = source;
                _bitmapImage.BeginInit();
                _bitmapImage.UriSource = new Uri(source);
                _bitmapImage.EndInit();
                _addImg.SetImageAditionalSource(_bitmapImage);
            }
        }

        private void AddImgOnAddImgButtonClick(object sender, EventArgs eventArgs)
        {
            SetImageRichTextBox();
        }

        private readonly IAddImg _addImg;
        private readonly BitmapImage _bitmapImage;
    }
}