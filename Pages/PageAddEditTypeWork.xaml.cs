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
    /// Логика взаимодействия для PageAddEditTypeWork.xaml
    /// </summary>
    public partial class PageAddEditTypeWork : Page
    {
        TypeWork _currentTypeWork = new TypeWork();
        public PageAddEditTypeWork(TypeWork _selectedTypeWork)
        {
            InitializeComponent();
            if (_selectedTypeWork != null)
            {
                _currentTypeWork = _selectedTypeWork;
            }
            DataContext = _currentTypeWork;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_currentTypeWork.Id == 0)
                {
                    DBContext.entObj.TypeWork.Add(_currentTypeWork);
                }
                DBContext.entObj.SaveChanges();
                PgFrame.subFrmObj.Navigate(new PageListTypeWork());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageListTypeWork());
        }
    }
}
