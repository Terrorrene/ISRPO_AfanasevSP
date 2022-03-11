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

namespace PishiStirai.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private byte[] _mainImageData; //переменная для хранения изображений
        public ProductPage()
        {
            InitializeComponent();

            if (App.CurrentUser?.UserRole == 2 || App.CurrentUser?.UserRole == 3)
                btnAddProduct.Visibility = Visibility.Visible;
            else
                btnAddProduct.Visibility = Visibility.Collapsed;

            comboDiscount.SelectedIndex = 0;
            comboSortBy.SelectedIndex = 0;
        }

        private void ComboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage());
        }
    }
}
