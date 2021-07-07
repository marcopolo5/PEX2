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
using StudentCarduri;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StudentModule : Window
    {
        private utilizator Utilizator;
        public StudentModule(utilizator Utilizator)
        {
            InitializeComponent();
           
                this.Utilizator = Utilizator;
                this.DB.Content = this.Utilizator.firstname;
                this.DataContext = this;
            
        }

        private void Open_Form(object sender, RoutedEventArgs e)
        {
            StudentCarduri.Formular FORMULAR= new StudentCarduri.Formular(Utilizator);
            this.Close();
            FORMULAR.Show();
        }

        private void Open_Map(object sender, RoutedEventArgs e)
        {
            /*StudentCarduri.Camine Camine_Harta= new StudentCarduri.Camine(Utilizator);
            Camine_Harta.Show();
            this.Hide();*/
            DateStudent dateStudent = new DateStudent(this.Utilizator);
            dateStudent.Show();
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login variabila_Login = new Login();
            variabila_Login.Show();
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

