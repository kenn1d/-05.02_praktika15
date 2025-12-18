using praktika15.Classes;
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

namespace praktika15.Pages
{
    /// <summary>
    /// Логика взаимодействия для Adduser.xaml
    /// </summary>
    public partial class Adduser : Page
    {
        public Adduser(UserContext userContext = null)
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.ViewUsers());
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
