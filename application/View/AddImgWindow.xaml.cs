using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using application.Controller;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для AddImgWindow.xaml
    /// </summary>
    public partial class AddImgWindow : IAddImg
    {
        public AddImgWindow(RichTextBox richTextBox)
        {
            InitializeComponent();
            _richTextBox = richTextBox;
            _controller = new AddImgController(this);
        }

        public ImageSource GetImageAditionalSource()
        {
            return ImageAdditionl.Source;
        }

        public void SetAtitionalImageSourcePath(string sourcePath)
        {
            var imgSource = new ImageSourceConverter();
            if (sourcePath != "")
            {
                ImageAdditionl.SetValue(Image.SourceProperty, imgSource.ConvertFromString(sourcePath));
            }
        }

        public void AddImgWindowClose()
        {
            Close();
        }

        public void SetImageAditionalSource(ImageSource source)
        {
            ImageAdditionl.Source = source;
        }

        public RichTextBox GetRichTextBoxt()
        {
            return _richTextBox;
        }

        private void ImgLoadingButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImgLoadingButtonClick != null)
            {
                ImgLoadingButtonClick(sender, e);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick(sender, e);
            }
        }

        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddImgButtonClick != null)
            {
                AddImgButtonClick(sender, e);
            }
        }

        public event EventHandler AddImgButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler ImgLoadingButtonClick;

        private readonly RichTextBox _richTextBox;
        private AddImgController _controller;

    }
}
