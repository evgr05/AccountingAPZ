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
    /// Логика взаимодействия для WindowChangePassword.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        Users _selectedUser = new Users();
        Users objUser;
        public WindowChangePassword(Users userObj, Users _currentUser)
        {
            InitializeComponent();
            _selectedUser = _currentUser;
            objUser = userObj;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (psbPassword.Password == psbRepPassword.Password)
                {
                    string hash = md5.hashPassword(psbRepPassword.Password);
                    _selectedUser.Password = hash;
                    DBContext.entObj.SaveChanges();
                    PgFrame.frmObj.Navigate(new PageUsers(objUser));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            catch (Exception ex)
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
