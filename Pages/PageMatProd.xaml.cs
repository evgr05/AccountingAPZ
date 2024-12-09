using AccountingAPZ.DataFiles;
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

namespace AccountingAPZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMatProd.xaml
    /// </summary>
    public partial class PageMatProd : Page
    {
        Users objUser;
        public PageMatProd(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            var productsObj = DBContext.entObj.Products.ToList();
            var materialObj = DBContext.entObj.Materials.ToList();
            ProductList.ItemsSource = productsObj;
            MaterialsList.ItemsSource = materialObj;
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tabProd.IsSelected == true)
            {
                WindowAddEditProducts windowAddEditProducts = new WindowAddEditProducts(objUser, null, null, 1);
                windowAddEditProducts.ShowDialog();
            }
            if(TabMat.IsSelected == true)
            {
                WindowAddEditProducts windowAddEditProducts = new WindowAddEditProducts(objUser, null, null, 2);
                windowAddEditProducts.ShowDialog();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMain(objUser));
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tabProd.IsSelected == true)
            {
                ProductList.ItemsSource = DBContext.entObj.Products.Where(x => x.Title.Contains(txbSearch.Text)).ToList();
            }
            if (TabMat.IsSelected == true)
            {
                MaterialsList.ItemsSource = DBContext.entObj.Materials.Where(x => x.Name.Contains(txbSearch.Text)).ToList();
            }
        }

        private void btnEditProd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditProducts windowAddEditProducts = new WindowAddEditProducts(objUser,(sender as Button).DataContext as Products , null, 1);
            windowAddEditProducts.ShowDialog();
        }

        private void btnDelProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данное изделие?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBContext.entObj.Products.Remove((sender as Button).DataContext as Products);
                    DBContext.entObj.SaveChanges();
                    ProductList.ItemsSource = DBContext.entObj.Products.ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelMat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данный материал?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBContext.entObj.Materials.Remove((sender as Button).DataContext as Materials);
                    DBContext.entObj.SaveChanges();
                    MaterialsList.ItemsSource = DBContext.entObj.Materials.ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditMat_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditProducts windowAddEditProducts = new WindowAddEditProducts(objUser, null, (sender as Button).DataContext as Materials, 2);
            windowAddEditProducts.ShowDialog();
        }

        private void tabProdMat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabProd.IsSelected == true)
            {
                PgFrame.headStr.Content = "Продукция";
            }
            if (TabMat.IsSelected == true)
            {
                PgFrame.headStr.Content = "Материалы";
            }
        }
    }
}
