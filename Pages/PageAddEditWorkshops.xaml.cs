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
    /// Логика взаимодействия для PageAddEditWorkshops.xaml
    /// </summary>
    public partial class PageAddEditWorkshops : Page
    {
        Workshops _selectedWorkshop = new Workshops();
        public PageAddEditWorkshops(Workshops _currentWorkshop)
        {
            InitializeComponent();
            if( _currentWorkshop != null )
            {
                _selectedWorkshop = _currentWorkshop;
            }
            DataContext = _selectedWorkshop;
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageListPosts());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedWorkshop.Id == 0)
                {
                    DBContext.entObj.Workshops.Add(_selectedWorkshop);
                }
                DBContext.entObj.SaveChanges();
                PgFrame.subFrmObj.Navigate(new PageListWorkshops());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
