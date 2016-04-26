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

        public void SetImageAditionalWidthSliperValue(int value)
        {
            ImageAditionalWidthSliper.Value = value;
        }

        public void SetImageAditionalHeightSliperValue(int value)
        {
            ImageAditionalHeightSliper.Value = value;
        }

        public bool IsImageAditionalLoaded()
        {
            return ((ImageAdditionl.IsLoaded) && (GetImageAditionalSource() != null));
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

        public void SetWidthValueToTextBox(int value)
        {
            WidthTextBox.Text = value.ToString();
        }

        public void SetHeightValueToTextBox(int value)
        {
            HeightTextBox.Text = value.ToString();
        }

        public int GetHeightValueFromTextBox()
        {
            return int.Parse(HeightTextBox.Text);
        }

        public int GetWidthValueFromTextBox()
        {
            return int.Parse(WidthTextBox.Text);
        }

        public int GetImageAditionalWidth()
        {
            return (int)ImageAdditionl.Source.Width;
        }

        public int GetImageAditionalHeight()
        {
            return (int)ImageAdditionl.Source.Height;
        }

        public void SetImageAditionalWidth(int widthValue)
        {
            ImageAdditionl.Width = widthValue;
        }

        public void SetImageAditionalHeigth(int heightValue)
        {
            ImageAdditionl.Height = heightValue;
        }

        private void HeightDecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (HeightDecrementButtonClick != null)
            {
                HeightDecrementButtonClick(sender, e);
            }
        }

        private void HeightIncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (HeightIncrementButtonClick != null)
            {
                HeightIncrementButtonClick(sender, e);
            }
        }

        private void WidthDecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (WidthDecrementButtonClick != null)
            {
                WidthDecrementButtonClick(sender, e);
            }
        }
        
        private void ImageAditionalHeightSliper_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ImageAditionalHeightSliperValueChanged != null)
            {
                ImageAditionalHeightSliperValueChanged(sender, e);
            }
        }

        private void ImageAditionalWidthSliper_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ImageAditionalWidthSliperValueChanged != null)
            {
                ImageAditionalWidthSliperValueChanged(sender, e);
            }
        }

        private void WidthIncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (WidthIncrementButtonClick != null)
            {
                WidthIncrementButtonClick(sender, e);
            }
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

        public event EventHandler HeightDecrementButtonClick;
        public event EventHandler HeightIncrementButtonClick;


        public event EventHandler WidthDecrementButtonClick;
        public event EventHandler WidthIncrementButtonClick;

        public event EventHandler ImageAditionalHeightSliperValueChanged;
        public event EventHandler ImageAditionalWidthSliperValueChanged;

        public event EventHandler AddImgButtonClick;

        public event EventHandler CancelButtonClick;
        public event EventHandler ImgLoadingButtonClick;

        private readonly RichTextBox _richTextBox;

        private AddImgController _controller;

    }
}