using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using application.Controller;
using application.Interface;

namespace application.View
{
    /// <summary>
    /// Логика взаимодействия для AddImgWindow.xaml
    /// </summary>
    public partial class AddImgWindow
    {
        public AddImgWindow()
        {
            InitializeComponent();
            _addImage = new AddImage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _addImage.GetImagePath();
            if (_addImage.ImagePath != "")
            {
                var bitmapImageBitmapSource = new BitmapImage();
                bitmapImageBitmapSource.BeginInit();
                bitmapImageBitmapSource.UriSource = new Uri(_addImage.ImagePath);
                bitmapImageBitmapSource.EndInit();
                ImageAdditionl.Source = bitmapImageBitmapSource;
            }
        }

        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private readonly AddImage _addImage;
    }
}
