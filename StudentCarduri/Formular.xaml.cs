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

namespace StudentCarduri
{
    /// <summary>
    /// Interaction logic for Formular.xaml
    /// </summary>
    public partial class Formular : Window
    {

        public Formular(utilizator Utilizator)
        {
            InitializeComponent();
            this.utilizator = Utilizator;
            this.DataContext = this;
            this.numeU.Content = this.utilizator.firstname;
            this.email.Content = this.utilizator.email;

        }

        public utilizator utilizator { get; set; }

        private void goto_HartaClick(object sender, RoutedEventArgs e)
        {

            Camine h = new Camine(this.utilizator);
            h.Show();
            this.Hide();
        }


    }
}
