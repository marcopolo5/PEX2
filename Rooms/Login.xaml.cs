using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data.SqlClient;
using Rooms.Entity;


namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

        }
        //Register2 register = new Register2();
        Welcome welcome = new Welcome();
        Register2 register = new Register2();
        SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404Last; integrated security=SSPI");

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Rooms.LoginRegister.Login login = new LoginRegister.Login();
            string email = textBoxEmail.Text;
            string password = passwordBox1.Password.ToString();

            try
            {
                utilizator autentificare = login.Verificare_User(email, password);
            }           

            catch (Exception exec)
            {
                textBoxEmail.Clear();
                passwordBox1.Clear();
                MessageBox.Show(exec.Message);
            }
/*
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Introdu o adresa de email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Introduceti o adresa de email valida.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404Last; integrated security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [utilizator] where email='" + email + "'  and password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["firstname"].ToString() + " " + dataSet.Tables[0].Rows[0]["lastname"].ToString();
                    welcome.TextBlockName.Text = username;//Sending value from one form to another form.
                    welcome.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Contul nu a fost gasit, reincercati !.";
                }
                con.Close();
            }*/
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            register.Show();
            Close();
        }

    }
}
