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
       
        private student student;

        int nr_camera, nr_camin;
        public StudentModule(utilizator Utilizator, student student)
       
        {
            InitializeComponent();
            this.Utilizator = Utilizator;
            this.student = student;
            this.DB.Content = this.Utilizator.firstname;
            this.DataContext = this;
            ShowFormStats();
            
        }

        public int GetStareFormular()
        {
            using (RoomsContext context = new RoomsContext())
            {

                var returneaza_form_conditionat = (from formular in context.Formular
                                                   where formular.StareFormular == Formular_Status.Admis
                                                   && formular.studentID == Utilizator.id
                                                   select formular).FirstOrDefault();

                if (returneaza_form_conditionat != null)
                {

                    nr_camera = (returneaza_form_conditionat).cameraID;
                   nr_camin = (returneaza_form_conditionat).caminID;

                    return 1;
                }
                else
                {
                    return 0;

                }
            }              

        }

        public int GetStareFormular2()
        {
            using (RoomsContext context = new RoomsContext())
            {

                var returneaza_form_conditionat = (from formular in context.Formular
                                                   where formular.StareFormular == Formular_Status.Respins
                                                   && formular.studentID == Utilizator.id
                                                   select formular).FirstOrDefault();

                if (returneaza_form_conditionat != null)
                {                


                    return 1;
                }
                else
                {
                    return 0;

                }
            }

        }

        private void Open_Form(object sender, RoutedEventArgs e)
        {
            StudentCarduri.Formular FORMULAR= new StudentCarduri.Formular(Utilizator, student);
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


        //Show room and camin
        public void ShowFormStats()
        {
            if (GetStareFormular() == 1)
            {
                StareFormularUI.Content = "Admis";
                NrCamera.Content = "Camera: " + nr_camera.ToString();
                NrCamin.Content = "Camin: " + nr_camin.ToString();
            }
            else if(GetStareFormular2()==1)
            {
                StareFormularUI.Content = "Respins";
            }          
            else{
                StareFormularUI.Content = "In Asteptare";

            }
                      
        }
        
                
    }
}

