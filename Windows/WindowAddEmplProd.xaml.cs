using AccountingAPZ.DataFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountingAPZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEmplProd.xaml
    /// </summary>
    public partial class WindowAddEmplProd : Window
    {
        private EmployeesProducts _selectedEmpl = new EmployeesProducts();
        Users objUser;
        public WindowAddEmplProd(EmployeesProducts _currentEmpl, Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            if( _currentEmpl != null)
            {
                _selectedEmpl = _currentEmpl;
            }
            DataContext = _selectedEmpl;            
            cmbNameEmpl.ItemsSource = DBContext.entObj.Employees.ToList();
            cmbProducts.ItemsSource = DBContext.entObj.Products.ToList();
            cmbTypeWork.ItemsSource = DBContext.entObj.TypeWork.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedEmpl.Id == 0)
                {
                    DBContext.entObj.EmployeesProducts.Add(_selectedEmpl);
                }
                DBContext.entObj.SaveChanges();
                PgFrame.frmObj.Navigate(new PageEmplProd(objUser));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
