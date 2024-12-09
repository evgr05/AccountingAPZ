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
    /// Логика взаимодействия для PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page
    {
        Users objUser;
        public PageEmployees(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            PgFrame.headStr.Content = "Сотрудники АПЗ";
            EmployeeList.ItemsSource = DBContext.entObj.Employees.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditEmpl windowAddEditEmpl = new WindowAddEditEmpl(null, objUser);
            windowAddEditEmpl.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMain(objUser));
        }

        private void cmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.FirstName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 1)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.SurName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 2)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Patronymic.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 3)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Adress.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 4)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Phone.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 5)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Workshops.Title.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 6)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Posts.Title.Contains(txbSearch.Text)).ToList();
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbSearch.SelectedIndex == 0)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.FirstName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 1)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.SurName.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 2)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Patronymic.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 3)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Adress.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 4)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Phone.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 5)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Workshops.Title.Contains(txbSearch.Text) || x.Workshops.WorkshopNubmer.Contains(txbSearch.Text)).ToList();
            }
            if (cmbSearch.SelectedIndex == 6)
            {
                EmployeeList.ItemsSource = DBContext.entObj.Employees.Where(x => x.Posts.Title.Contains(txbSearch.Text)).ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditEmpl windowAddEditEmpl = new WindowAddEditEmpl((sender as Button).DataContext as Employees, objUser);
            windowAddEditEmpl.Show();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данного сотрудника?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBContext.entObj.Employees.Remove((sender as Button).DataContext as Employees);
                    DBContext.entObj.SaveChanges();
                    EmployeeList.ItemsSource = DBContext.entObj.Employees.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
