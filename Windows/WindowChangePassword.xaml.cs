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
        int passRezult;
        public WindowChangePassword(Users userObj, Users _currentUser)
        {
            InitializeComponent();
            _selectedUser = _currentUser;
            objUser = userObj;
            DataContext = _selectedUser;
            errTblck.Text = "Пароль не может быть пустым";
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (psbPassword.Password.Length == 0 || psbRepPassword.Password.Length == 0)
                {
                    if (psbPassword.Password != psbRepPassword.Password)
                        errors.AppendLine("Пароли не совпадают");
                    else
                        errors.AppendLine("Введите пароль");
                }
                if (passRezult < 3)
                {
                    errors.AppendLine("Папрль слишком простой, придумайте посложнее!");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                if (errors.Length == 0)
                {
                    string hash = md5.hashPassword(psbRepPassword.Password);
                    _selectedUser.Password = hash;
                    DBContext.entObj.SaveChanges();
                    PgFrame.frmObj.Navigate(new PageUsers(objUser));
                    this.Close();
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

        private void psbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (psbPassword.Password == psbRepPassword.Password)
            {
                if (psbRepPassword.Password.Length > 3)
                {
                    passRezult = PasswordStrengthChecker.GetPasswordStrengthChecker(psbPassword.Password);
                    passwordProgress.Value = passRezult;
                    if (passwordProgress.Value < 3)
                    {
                        errTblck.Text = "Пароль слишком простой";
                    }
                    if (passwordProgress.Value == 3)
                    {
                        errTblck.Text = "Средний пароль";
                    }
                    if (passwordProgress.Value > 3)
                    {
                        errTblck.Text = "Хороший пароль";
                    }
                }                
                if (psbPassword.Password.Length <= 3)
                {
                    errTblck.Text = "Нужно минимум 4 символа";
                }
                if (psbPassword.Password.Length == 0)
                {
                    errTblck.Text = "Пароль не может быть пустым";
                }                
            }
            else
            {
                errTblck.Text = "Пароли не совпадают!";
                passwordProgress.Value = 0;
            }
        }
    }
}
