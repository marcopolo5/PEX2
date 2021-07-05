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
using Rooms.Entity;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DateStudent : Window
    {
        public utilizator Utilizator;

        public DateStudent(utilizator Utilizator)
        {
            InitializeComponent();
            this.Utilizator = Utilizator;
            this.DataContext = this;
        }

        public student student;
        private void TrimiteDate_Click(object sender, RoutedEventArgs e)
        {
            student student = new student();
            Rooms.LoginRegister.DateStudent dateStudent = new LoginRegister.DateStudent();
            //float medie = Single.Parse(EnterMedie.ToString());
            float medie = float.Parse(EnterMedie.Text);
            string nr_telefon = EnterNrTel.Text.ToString();
            string facultate = EnterFacultate.Text.ToString();


            student.medie = medie;
            student.nr_telefon = nr_telefon;
            student.facultate = facultate;
            //student.nume = this.Utilizator.firstname;
            //student.prenume = this.Utilizator.lastname;
            try
            {
                dateStudent.Valideaza_Date((float)medie, nr_telefon, facultate,this.Utilizator.firstname,this.Utilizator.lastname);
                try
                {
                    foreach(Window window in Application.Current.Windows)
{
                        if (window.GetType() == typeof(MainWindow1))
                        {
                            (window as MainWindow1).FormularButton.Visibility = Visibility.Visible;
                        }
                    }
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Datele au fost introduse gresit !");
                }
                   
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }

}
