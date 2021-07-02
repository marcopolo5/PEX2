﻿using System;
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
        private utilizator Utilizator;
        public Login()
        {
            InitializeComponent();
            Utilizator = new utilizator();
        }
        
        //Register2 register = new Register2();
        Register2 register = new Register2();

        public void ShowMainWindow(utilizator user)
        {
            MainWindow1 mainWindow = new MainWindow1(user);
            mainWindow.SetUser(user);
            mainWindow.Show();
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Rooms.LoginRegister.Login login = new LoginRegister.Login();
            string email = textBoxEmail.Text;
            string password = passwordBox1.Password.ToString();


            try
            {
                utilizator loggedUser = login.Verificare_User(email, password);

                if (loggedUser.Role.ToString().Equals("Membru"))
                {
                    MainWindow1 mainWindow = new MainWindow1(loggedUser);
                    mainWindow.Show();
                    this.Close();
                }
                else if (loggedUser.Role.ToString().Equals("Administrator"))
                {
                    MainWindowAdmin mainWindowAdmin = new MainWindowAdmin(loggedUser);
                    mainWindowAdmin.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                textBoxEmail.Clear();
                passwordBox1.Clear();
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            register.Show();
            Close();
        }

    }
}
