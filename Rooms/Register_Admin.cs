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
    public partial class Register_Admin : Window
    {

        public utilizator utilizator;

        public Register_Admin()
        {
            InitializeComponent();
            utilizator = new utilizator();
           // SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404Last; integrated security=SSPI");

        }

        public void ShowMainWindow(utilizator user)
        {
           /* Rooms.MainWindow mainWindow = new MainWindow();
            mainWindow.SetUser(user);
            mainWindow.Show();
            this.Close();*/
        }


        private void RegisterBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Rooms.LoginRegister.Register register = new LoginRegister.Register();
            string username = EnterUsername.Text;
            string password = EnterPassword.Password.ToString();
            string confirmpassword = ConfirmPassword.Password.ToString();
            string firstname = EnterName.Text;
            string lastname = EnterSurname.Text;

            bool checkInstructor;
            if (InstructorRadioBtn.IsChecked == true)
            {
                MessageBox.Show("sunt aici");
                checkInstructor = true;
            }
            else
            {
                MessageBox.Show("sunt aiici");
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
                MessageBox.Show("Welcome to our application. Enjoy!");


                if (newUser.Role.ToString().Equals("Administrator"))
                {
                    MessageBox.Show("Aici sunt nu ma mai cauta la admin");
                    MainWindowAdmin mainWindow = new MainWindowAdmin(utilizator);
                    mainWindow.Show();
                    this.Close();
                }
                else if (newUser.Role.ToString().Equals("Membru"))
                {
                    MessageBox.Show("Hello aici sunt nu ma mai cauta la membru");
                    /* Rooms.Entity.cevaceammodificatdinMainWindow mainTrainerView = new Entity.cevaceammodificatdinMainWindow(newUser);
                     mainTrainerView.Show();
                     this.Close();*/
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
                App.Current.MainWindow.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}