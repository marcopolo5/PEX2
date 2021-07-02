using Rooms.Entity;
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
using static Student.Cards;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for Formular.xaml
    /// </summary>
    public partial class Formular : Window
    {
        public Formular()
        {
            InitializeComponent();
        }

        private void goto_HartaClick(object sender, RoutedEventArgs e)
        {
            //Harta h = new Harta();
           // h.Show();
            this.Hide();
        }

        /*public static implicit operator Formular(formular v)
        {
            throw new NotImplementedException();
        }*/
    }
}
