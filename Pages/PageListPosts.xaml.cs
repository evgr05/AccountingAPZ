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
    /// Логика взаимодействия для PageListPosts.xaml
    /// </summary>
    public partial class PageListPosts : Page
    {
        public PageListPosts()
        {
            InitializeComponent();
            PostsList.ItemsSource = DBContext.entObj.Posts.ToList();
        }

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageAddEditPosts(null));
        }        

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {
            Posts postForEdit = PostsList.SelectedItem as Posts;
            PgFrame.subFrmObj.Navigate(new PageAddEditPosts(postForEdit));
        }

        private void delMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить эту должность", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Posts postForRemove = PostsList.SelectedItem as Posts;
                    DBContext.entObj.Posts.Remove(postForRemove);
                    DBContext.entObj.SaveChanges();
                    PgFrame.subFrmObj.Navigate(new PageListPosts());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
