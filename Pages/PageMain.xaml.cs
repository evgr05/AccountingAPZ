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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        Users objUser;
        public PageMain(Users userObj)
        {
            InitializeComponent();
            objUser = userObj;
            PgFrame.headStr.Content = "Главное меню";
        }

        private void btnProduction_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageMatProd(objUser));
        }


        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageEmployees(objUser));

        }

        private void btnEmplProd_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageEmplProd(objUser));

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            PgFrame.frmObj.Navigate(new PageLogin());
        }
    }
}
