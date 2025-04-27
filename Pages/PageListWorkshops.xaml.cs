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
    /// Логика взаимодействия для PageListWorkshops.xaml
    /// </summary>
    public partial class PageListWorkshops : Page
    {
        public PageListWorkshops()
        {
            InitializeComponent();
            WorkshopsList.ItemsSource = DBContext.entObj.Workshops.ToList();
        }

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageAddEditWorkshops(null));
        }

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {
            Workshops workshopForEdit = WorkshopsList.SelectedItem as Workshops;
            PgFrame.subFrmObj.Navigate(new PageAddEditWorkshops(workshopForEdit));
        }

        private void delMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот цех", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Workshops workshopForRemoving = WorkshopsList.SelectedItem as Workshops;
                    DBContext.entObj.Workshops.Remove(workshopForRemoving);
                    DBContext.entObj.SaveChanges();
                    PgFrame.subFrmObj.Navigate(new PageListWorkshops());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
