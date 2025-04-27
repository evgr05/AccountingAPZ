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
    /// Логика взаимодействия для PageAddEditPosts.xaml
    /// </summary>
    public partial class PageAddEditPosts : Page
    {
        Posts _currentPost = new Posts();
        public PageAddEditPosts(Posts _selectedPost)
        {
            InitializeComponent();
            if( _selectedPost != null )
            {
                _currentPost = _selectedPost;
            }
            DataContext = _currentPost;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if( _currentPost.Id == 0)
                {
                    DBContext.entObj.Posts.Add(_currentPost);
                }
                DBContext.entObj.SaveChanges();
                PgFrame.subFrmObj.Navigate(new PageListPosts());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.subFrmObj.Navigate(new PageListPosts());
        }
    }
}
