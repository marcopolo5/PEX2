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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Rooms.Entity;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Introdu o adresa de email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Introdu o adresa de email valida.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Introdu parola.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Introdu parola inca o data.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Parola de confirmare trebuie sa fie la fel ca parola initiala.";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    string address = textBoxAddress.Text;

                    SqlConnection con = new SqlConnection("Data Source=ZEROLEGION\\SQLEXPRESS;Initial Catalog=Rooms404_Project_DB; integrated security=SSPI");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into [utilizator] ([firstname],[lastname],[email],[parola],[address]) values(@firstname,@lastname,@email,@parola,@address)", con);

                    /*  wanna cry method  SqlCommand cmd = new SqlCommand("Insert into user ([firstname],[lastname],[email],[password],[address]) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "')", con);
                               someone help me i'm having a seizure here....*/
                    /* I wanna die test -- > it not works either ofc why it would work
                     *        SqlCommand cmd = new SqlCommand("Insert into user values (@firstname,@lastname,@email,@password,@address",con);
                    cmd.Parameters.AddWithValue("@firstname", int.Parse(textBoxFirstName.Text));
                    cmd.Parameters.AddWithValue("@lastname", int.Parse(textBoxLastName.Text));
                    cmd.Parameters.AddWithValue("@email", int.Parse(textBoxEmail.Text));
                    cmd.Parameters.AddWithValue("@password", int.Parse(passwordBox1.Password));
                     */

                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = textBoxFirstName.Text;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = textBoxLastName.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBoxEmail.Text;
                    cmd.Parameters.Add("@parola", SqlDbType.VarChar).Value = passwordBox1.Password.ToString();
                    cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = textBoxAddress.Text;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "Te ai inregistrat cu succes !.";
                    Reset();
                }
            }
        }
    }
}
