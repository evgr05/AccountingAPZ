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
    /// Логика взаимодействия для PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        Users objUser;
        public PageUsers(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            PgFrame.headStr.Content = "Пользователи";
            if (objUser.RoleId != 1 || objUser == null)
            {
                MessageBox.Show("У вас недостаточно прав для перехода на данную страницу!","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                PgFrame.frmObj.Navigate(new PageMain(objUser));
            }
            UsersList.ItemsSource = DBContext.entObj.Users.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMain(objUser));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
