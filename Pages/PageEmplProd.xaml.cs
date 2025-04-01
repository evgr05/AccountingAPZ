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
    /// Логика взаимодействия для PageEmplProd.xaml
    /// </summary>
    public partial class PageEmplProd : Page
    {
        
        Users objUser;
        public PageEmplProd(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.ToList();
            PgFrame.headStr.Content = "Изготовленная продукция";
            dateCol.Binding.StringFormat = "dd.MM.yyyy";
            


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEmplProd windowAddEmplProd = new WindowAddEmplProd((sender as Button).DataContext as EmployeesProducts, objUser);
            windowAddEmplProd.Show();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Вы действительно хотите удалить данную запись?", 
                    "Удаление", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBContext.entObj.EmployeesProducts.Remove((sender as Button).DataContext as EmployeesProducts);
                    DBContext.entObj.SaveChanges();
                    prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.ToList();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEmplProd windowAddEmplProd = new WindowAddEmplProd(null, objUser);
            windowAddEmplProd.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMain(objUser));
        }



        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.FirstName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 1)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.SurName.Contains(txbSearch.Text)).ToList();
            }
            if(cmbSearch.SelectedIndex == 2)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.Patronymic.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 3)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Count.ToString().Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 4)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Date.ToString().Contains(txbSearch.Text)).ToList();
            }

        }

        private void cmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.FirstName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 1)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.SurName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 2)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Employees.Patronymic.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 3)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Count.ToString().Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 4)
            {
                prodGrid.ItemsSource = DBContext.entObj.EmployeesProducts.Where(x => x.Date.ToString().Contains(txbSearch.Text)).ToList();
            }
        }
    }
}
