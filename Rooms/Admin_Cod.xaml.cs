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

namespace Rooms
{
    /// <summary>
    /// Interaction logic for AboutUs.xaml
    /// </summary>
    public partial class Admin_Cod : Window
    {
        public Admin_Cod()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        Register_Admin register_Admin = new Register_Admin();

        MainWindow mainWindow = new MainWindow();

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (textboxAdminCode.Text == "495836")
            {
                register_Admin.Show();
                this.Hide();
                mainWindow.Hide();
            }    
        }
    }
}
