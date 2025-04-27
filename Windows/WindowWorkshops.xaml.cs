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
    /// Логика взаимодействия для WindowWorkshops.xaml
    /// </summary>
    public partial class WindowWorkshops : Window
    {
        public WindowWorkshops()
        {
            InitializeComponent();
            PgFrame.subFrmObj = frmWorkshops;
            PgFrame.subFrmObj.Navigate(new PageListWorkshops());
        }
    }
}
