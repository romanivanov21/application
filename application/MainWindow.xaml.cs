using application.Controller;
using application.Interface;
using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
            conteroller_ = new application.Controller.Controller(this);
        }
        private application.Controller.Controller conteroller_;

        public void WindowInit(List<Entry> mainListView)
        {
            mainListVliew_.ItemsSource = mainListView;
            mainListVliew_.Items.Refresh();
        }
    }
}
