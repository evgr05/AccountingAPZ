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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            PgFrame.headStr.Content = "Авторизация";
            
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hash = md5.hashPassword(psbPassword.Password);
                var userObj = DBContext.entObj.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == hash);
                if (userObj != null)
                {
                    PgFrame.frmObj.Navigate(new PageMain(userObj));
                }
                else
                {
                    MessageBox.Show("Неправильное имя пользователя или пароль", "Ошибка");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
