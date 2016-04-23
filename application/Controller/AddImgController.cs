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
            var bitmapImage = new BitmapImage(new Uri(_addImg.GetImageAditionalSource().ToString()));
            Clipboard.SetImage(bitmapImage);
            richTextBox.Paste();
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
        private readonly BitmapImage _bitmapImage;
    }
}
