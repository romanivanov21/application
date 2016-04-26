using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace application.Interface
{
    internal interface IAddImg
    {
        event EventHandler HeightDecrementButtonClick;
        event EventHandler HeightIncrementButtonClick;

        event EventHandler WidthDecrementButtonClick;
        event EventHandler WidthIncrementButtonClick;

        event EventHandler ImageAditionalHeightSliperValueChanged;
        event EventHandler ImageAditionalWidthSliperValueChanged;

        event EventHandler ImgLoadingButtonClick;

        event EventHandler CancelButtonClick;
        event EventHandler AddImgButtonClick;

        ImageSource GetImageAditionalSource();
        void SetImageAditionalSource(ImageSource source);
        void SetAtitionalImageSourcePath(string source);

        void SetWidthValueToTextBox(int value);
        void SetHeightValueToTextBox(int value);

        int GetWidthValueFromTextBox();
        int GetHeightValueFromTextBox();

        int GetImageAditionalWidth();
        int GetImageAditionalHeight();

        void SetImageAditionalHeigth(int heightValue);
        void SetImageAditionalWidth(int widthValue);

        void SetImageAditionalWidthSliperValue(int value);
        void SetImageAditionalHeightSliperValue(int value);

        bool IsImageAditionalLoaded();
        void AddImgWindowClose();

        RichTextBox GetRichTextBoxt();
    }
}
