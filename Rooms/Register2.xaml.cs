using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;
//using MySql.Data.MySqlClient;
//using System.Speech.Recognition;
using System.Text.RegularExpressions;
//using System.Speech.Synthesis;
using System.Threading;
using Rooms.Entity;


namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register2 : Window
    {

        private utilizator utilizator;

        public Register2()
        {
            InitializeComponent();
            utilizator = new utilizator();
            SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404Last; integrated security=SSPI");

        }

        public void ShowMainWindow(utilizator user)
        {
            Rooms.MainWindow mainWindow = new MainWindow();
            mainWindow.SetUser(user);
            mainWindow.Show();
            this.Close();
        }


        private void RegisterBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Rooms.LoginRegister.Register register = new LoginRegister.Register();
            string username = EnterUsername.Text;
            string password = EnterPassword.Password.ToString();
            string confirmpassword = ConfirmPassword.Password.ToString();
            string firstname =EnterName.Text;
            string lastname = Surnametxt.Text;

            bool checkInstructor;
            if (InstructorRadioBtn.IsChecked == true)
            {
                checkInstructor = true;
            }
            else
            {
                checkInstructor = false;
            }


            string email = EnterEmail.Text;
            utilizator.username = username;
            utilizator.password = password;
            utilizator.firstname = firstname;
            utilizator.lastname = lastname;
            utilizator.email = email;
            utilizator.Role = InstructorRadioBtn.IsEnabled ? Rol_Utilizator.Membru : Rol_Utilizator.Administrator;

            try
            {
                utilizator newUser = register.Valideaza_Inregistrare(username, password, firstname, lastname, confirmpassword, checkInstructor, email);
                MessageBox.Show("You're now a part of our e-Learning community. Enjoy!");


                if (newUser.Role.ToString().Equals("Membru"))
                {
                   Rooms.MainWindow  mainWindow = new MainWindow(newUser);
                    mainWindow.Show();
                    this.Close();
                }
                else if (newUser.Role.ToString().Equals("Administrator"))
                {
                    Rooms.Entity.MainWindow mainTrainerView = new Entity.MainWindow(newUser);
                    mainTrainerView.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                EnterUsername.Clear();
                EnterPassword.Clear();
                EnterName.Clear();
                EnterSurname.Clear();
                EnterEmail.Clear();

                MessageBox.Show(ex.Message);
            }
        }
        
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
    }
}