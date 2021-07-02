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
using System.Data.Entity;
using Rooms.Entity;
using System.Diagnostics;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow(utilizator utilizator)
        {

            InitializeComponent();

            this.utilizator = utilizator;
            this.DataContext = this;
        }
        public MainWindow()
        {

        }
        public utilizator utilizator { get; set; }

        Login Login = new Login();

        public void SetUser(utilizator utilizator)
        {
            Debug.WriteLine("set user: user = " + utilizator + " user id = " + utilizator.id);
            this.utilizator = utilizator;
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login.Show();
            Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void DespreNoi(object sender, RoutedEventArgs e)
        {
            AboutUs about = new AboutUs();
            about.Show();
        }

        private void Admin(object sender, RoutedEventArgs e)
        {
            Admin_Cod admin_Cod = new Admin_Cod();
            admin_Cod.Show();
        }
    }
}

