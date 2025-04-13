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
    /// Логика взаимодействия для WindowAddEditEmpl.xaml
    /// </summary>
    public partial class WindowAddEditEmpl : Window
    {
        Users objUser;
        private Employees _selectedEmpl = new Employees();
        public WindowAddEditEmpl(Employees _currentEmpl, Users oserObj)
        {
            InitializeComponent();
            objUser = oserObj;
            if (_currentEmpl != null)
            {
                _selectedEmpl = _currentEmpl;
            }
            DataContext = _selectedEmpl;
            cmbPosts.ItemsSource = DBContext.entObj.Posts.ToList();
            cmbWorkshops.ItemsSource = DBContext.entObj.Workshops.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedEmpl.Id == 0)
                {
                    DBContext.entObj.Employees.Add(_selectedEmpl);
                }
                DBContext.entObj.SaveChanges();
                PgFrame.frmObj.Navigate(new PageEmployees(objUser));
                this.Close();
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
