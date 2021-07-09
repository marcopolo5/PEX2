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
using Rooms.Entity;

namespace StudentCarduri
{  /// <summary>
   /// Interaction logic for cardCamin.xaml
   /// </summary>
    public partial class cardCamin : UserControl
    {
        private utilizator Utilizator;
        public student Student;
        public cardCamin(camin caminn, utilizator Utilizator,student student)
        {
            InitializeComponent();
            this.camin = caminn;
            this.DataContext = this;
            this.Utilizator = Utilizator;
            this.Student = student;
        }
        public camin camin { get; set; }

        private void vizualizareCamere(object sender, MouseButtonEventArgs e)
        {
            Camere camere = new Camere(this.camin, this.Utilizator,this.Student);
            camere.Show();
            foreach (var camineWindow in Application.Current.Windows)
            {
                if (camineWindow is Camine)
                {
                    (camineWindow as Window).Close();
                }
            }
        }
    }
}
