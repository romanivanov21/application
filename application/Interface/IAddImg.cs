using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace application.Interface
{
    internal interface IAddImg
    {
        event EventHandler ImgLoadingButtonClick;
        event EventHandler CancelButtonClick;
        event EventHandler AddImgButtonClick;

        ImageSource GetImageAditionalSource();
        void SetImageAditionalSource(ImageSource source);
        void SetAtitionalImageSourcePath(string source);
        void AddImgWindowClose();
        RichTextBox GetRichTextBoxt();
    }
}
