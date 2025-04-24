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
using System.Windows.Shapes;

namespace AccountingAPZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEditProducts.xaml
    /// </summary>
    public partial class WindowAddEditProducts : Window
    {
        Users objUser;
        private Products _currentProd = new Products();
        private Materials _currentMat = new Materials();
        private int _valueSave;
        public WindowAddEditProducts(Users userObj, Products _selectedProd, Materials _selectedMat, int val)
        {
            InitializeComponent();
            objUser = userObj;
            _valueSave = val;
            if (val == 1)
            {
                txbProd.Visibility = Visibility.Visible;
                if (_selectedProd != null)
                {
                    _currentProd = _selectedProd;
                }
                DataContext = _currentProd;

                DataContext = _currentProd;
            }
            if (val == 2)
            {
                txbMat.Visibility = Visibility.Visible;
                if( _selectedMat != null)
                {
                    _currentMat = _selectedMat;
                }
                DataContext = _currentMat;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_valueSave == 1)
                {
                    if (_currentProd != null)
                    {
                        if (_currentProd.Id == 0)
                        {
                            DBContext.entObj.Products.Add(_currentProd);
                        }
                        DBContext.entObj.SaveChanges();
                        PgFrame.frmObj.Navigate(new PageMatProd(objUser));
                        this.Close();
                    }
                }
                if (_valueSave == 2)
                {
                    if (_currentMat != null)
                    {
                        if (_currentProd != null)
                        {
                            if (_currentMat.Id == 0)
                            {
                                DBContext.entObj.Materials.Add(_currentMat);
                            }
                            DBContext.entObj.SaveChanges();
                            PgFrame.frmObj.Navigate(new PageMatProd(objUser));
                            this.Close();
                        }
                    }
                }
            }
            catch(Exception ex)
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
