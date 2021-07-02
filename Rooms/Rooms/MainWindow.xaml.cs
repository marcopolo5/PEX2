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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            using (var context = new RoomsContext())
            {


                var Rol_Utilizator = new Rol_Utilizator
                {
                    rol = "administrator"

                };
                context.Tip.Add(Rol_Utilizator);
                context.SaveChanges();
            }


        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

