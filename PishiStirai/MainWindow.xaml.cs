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
using PishiStirai.Pages;

namespace PishiStirai
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Content = new LoginPage();
            FrameMain.LoadCompleted += LoginPage_LoadCompleted;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FrameMain_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (!FrameMain.CanGoBack)
                BtnBack.Content = "Показать товары";
            else
                FrameMain.Navigate(new ProductPage());
        }
    }
}
