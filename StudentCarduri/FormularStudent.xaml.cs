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
    /// Interaction logic for FormularStudent.xaml
    /// </summary>
    public partial class FormularStudent : Window
    {
        //public camin Camin;
        // public camera Camera;
        // public utilizator Utilizator;


        public FormularStudent(utilizator Utilizator, camin Camin, camera Camera)
        {
            InitializeComponent();
            this.camera = Camera;
            this.camin = Camin;
            this.utilizator = Utilizator;
            this.DataContext = this;
        }


        public camera camera { get; set; }
        public camin camin { get; set; }
        public utilizator utilizator { get; set; }

        private void goto_HartaClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
