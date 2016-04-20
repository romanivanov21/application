using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace application.Interface
{
    internal interface IAddImg
    {
        event EventHandler ImgLoadingButtonClick;
        event EventHandler AddImgButtonClick;

        void SetImageAditionalSource(ImageSource source);
        RichTextBox GetRichTextBoxt();
    }
}
