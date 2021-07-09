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
using System.Speech.Recognition;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Threading;
using Rooms.Entity;


namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register_Student : Window
    {
        SpeechRecognitionEngine spchrec = new SpeechRecognitionEngine();
        SpeechSynthesizer spchsint = new SpeechSynthesizer();
        Grammar word = new DictationGrammar();

        public utilizator utilizator;
        public student student;

        public Register_Student()
        {
            InitializeComponent();
            utilizator = new utilizator();


            // SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404Last; integrated security=SSPI");
            Choices commands = new Choices();
            commands.Add(new string[] { "first", "second", "user", "email", "password", "repeat password", "admin" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(commands);
            Grammar grammar = new Grammar(gbuilder);
           /* spchrec.LoadGrammarAsync(grammar);
            spchrec.SetInputToDefaultAudioDevice();
            spchrec.SpeechRecognized += spchrec_SpeechRecognized;
            spchrec.RecognizeAsync(RecognizeMode.Multiple);
           // spchsint.Rate = -3;
          //  spchsint.Volume = 10;*/


        }
        /*void spchrec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "first":
                    spchsint.SpeakAsync("Please enter your name: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                    }
                    EnterName.Focus();
                    break;
                case "second":
                    spchsint.SpeakAsync("Please enter your surname: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                    }
                    EnterSurname.Focus();
                    break;
                case "user":
                    spchsint.SpeakAsync("Please enter your username: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                        Thread.Sleep(2000);
                    }
                    EnterUsername.Focus();
                    break;
                case "email":
                    spchsint.SpeakAsync("Please enter your email: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                        Thread.Sleep(2000);
                    }
                    EnterEmail.Focus();
                    break;
                case "password":
                    spchsint.SpeakAsync("Please enter your password: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                        Thread.Sleep(2000);
                    }
                    EnterPassword.Focus();
                    break;
                case "repeat password":
                    spchsint.SpeakAsync("Please reenter the password: ");
                    Thread.Sleep(2000);
                    if (spchrec.AudioState != AudioState.Speech)
                    {
                        spchrec.RequestRecognizerUpdate();
                        Thread.Sleep(2000);
                    }
                    ConfirmPassword.Focus();
                    break;
                case "admin":
                    Admin_Cod administrator = new Admin_Cod();
                    administrator.Show();
                    this.Close();
                    spchrec.RecognizeAsyncStop();
                    spchsint.Pause();
                    break;
            }
        }*/

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
            string firstname = EnterName.Text;
            string lastname = EnterSurname.Text;

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
                MessageBox.Show("Welcome to Rooms 404. Enjoy!");

                AdminFormularService adminFormularService = new AdminFormularService();

                student = adminFormularService.GetStudent(utilizator.id);

                if (newUser.Role.ToString().Equals("Membru"))
                {
                    StudentModule mainWindow = new StudentModule(utilizator,student);
                    mainWindow.Show();
                    this.Close();
                }
                else if (newUser.Role.ToString().Equals("Administrator"))
                {
                    AdminModule adminModule = new AdminModule(utilizator);
                    adminModule.Show();
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
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}