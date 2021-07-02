using Rooms.Entity;
using Student;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        private utilizator Utilizator;
        public MainWindow1(utilizator Utilizator)
        {
            InitializeComponent();
           
                this.Utilizator = Utilizator;
                this.DB.Content = this.Utilizator.firstname;
                this.DataContext = this;
            
        }

        private void Open_Form(object sender, RoutedEventArgs e)
        {
            Formular f = new Formular();
            this.Close();
            f.Show();
        }

        private void Open_Map(object sender, RoutedEventArgs e)
        {
            //test t = new test();
            //t.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SetUser(utilizator utilizator)
        {
            Debug.WriteLine("set user: user = " + utilizator + " user id = " + utilizator.id);
            this.Utilizator = utilizator;
        }

    }
}

