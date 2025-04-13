using AccountingAPZ.DataFiles;
using AccountingAPZ.Windows;
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
            usersList.ItemsSource = DBContext.entObj.Users.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMain(objUser));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditUsers windowAddEditUsers = new WindowAddEditUsers(objUser, null);
            windowAddEditUsers.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddEditUsers windowAddEditUsers = new WindowAddEditUsers(objUser, (sender as Button).DataContext as Users);
            windowAddEditUsers.ShowDialog();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите удалить данную запись?",
                    "Удаление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DBContext.entObj.Users.Remove((sender as Button).DataContext as Users);
                    DBContext.entObj.SaveChanges();
                    usersList.ItemsSource = DBContext.entObj.Users.ToList();
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            usersList.ItemsSource = DBContext.entObj.Users.Where(x => x.Employees.FirstName.Contains(txbSearch.Text) ||
            x.Employees.SurName.Contains(txbSearch.Text) ||
            x.Employees.Patronymic.Contains(txbSearch.Text) ||
            x.Employees.Workshops.Title.Contains(txbSearch.Text) ||
            x.Employees.Posts.Title.Contains(txbSearch.Text) ||
            x.Login.Contains(txbSearch.Text) ||
            x.Role.Title.Contains(txbSearch.Text)).ToList();
        }

        private void btnChanPass_Click(object sender, RoutedEventArgs e)
        {
            WindowChangePassword windowChangePassword = new WindowChangePassword(objUser, (sender as Button).DataContext as Users);
            windowChangePassword.ShowDialog();
        }
    }
}
