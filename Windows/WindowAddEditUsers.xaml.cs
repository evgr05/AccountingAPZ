using AccountingAPZ.DataFiles;
using AccountingAPZ.Pages;
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

namespace AccountingAPZ.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEditUsers.xaml
    /// </summary>
    public partial class WindowAddEditUsers : Window
    {
        Users _selectedUser = new Users();
        Users objUser;
        public WindowAddEditUsers(Users userObj, Users _currentUser)
        {
            InitializeComponent();
            objUser = userObj;
            if (_currentUser != null )
            {
                _selectedUser = _currentUser;
            }
            cmbEmpl.ItemsSource = DBContext.entObj.Employees.ToList();
            cmbRole.ItemsSource = DBContext.entObj.Role.ToList();
            DataContext = _selectedUser;
        }

        private void bckBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(_selectedUser.Login))
                    errors.AppendLine("Введите логин");
                if(_selectedUser.Employees == null)
                    errors.AppendLine("Выберите сотрудника");
                if (_selectedUser.Role == null)
                    errors.AppendLine("Выберите роль");
                if (_selectedUser.Id == 0)
                {
                    int userExist = DBContext.entObj.Users.Count(x => x.Login == txbLogin.Text);
                    if (userExist != 0)
                        errors.AppendLine($"Пользователь с именем {txbLogin.Text} уже существует.");
                }                
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(),
                        "Произошла ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (_selectedUser.Id == 0)
                {
                    DBContext.entObj.Users.Add(_selectedUser);
                    DBContext.entObj.SaveChanges();
                    PgFrame.frmObj.Navigate(new PageUsers(objUser));
                }
                DBContext.entObj.SaveChanges();
                PgFrame.frmObj.Navigate(new PageUsers(objUser));
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
