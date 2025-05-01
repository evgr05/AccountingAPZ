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
    /// Логика взаимодействия для PageListTypeWork.xaml
    /// </summary>
    public partial class PageListTypeWork : Page
    {
        public PageListTypeWork()
        {
            InitializeComponent();
            TypeWorkList.ItemsSource = DBContext.entObj.TypeWork.ToList();
        }

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageAddEditTypeWork(null));
        }

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {
            TypeWork typeworkForEdit = TypeWorkList.SelectedItem as TypeWork;
            PgFrame.subFrmObj.Navigate(new PageAddEditTypeWork(typeworkForEdit));
        }

        private void delMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот тип работы?", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TypeWork typeworkForRemove = TypeWorkList.SelectedItem as TypeWork;
                    DBContext.entObj.TypeWork.Remove(typeworkForRemove);
                    DBContext.entObj.SaveChanges();
                    PgFrame.subFrmObj.Navigate(new PageListTypeWork());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
