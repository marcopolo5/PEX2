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
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    /// <summary>
    /// Interaction logic for cardCamera.xaml
    /// </summary>
    public partial class cardCamera : UserControl
    {
        private utilizator Utilizator;
        private camin Camin;
        public cardCamera(camera Camera, camin caminn, utilizator Utilizator,student student)
        {
            InitializeComponent();
            this.camera = Camera;
            this.Camin = caminn;
            this.DataContext = this;
            this.Utilizator = Utilizator;
            this.Student = student;
            this.DataContext = this;

        }
        public camera camera { get; set; }
        public student Student { get; set; }

        private void insertOption(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataFormular form = new DataFormular();
                form.VerificareFormular(this.Utilizator.id, this.Camin.id, camera.id);

                FormularStudent formular = new FormularStudent(this.Utilizator, this.Camin, this.camera,this.Student);
                formular.Show();
                foreach (var camereWindow in Application.Current.Windows)
                {
                    if (camereWindow is Camere)
                    {
                        (camereWindow as Window).Close();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
