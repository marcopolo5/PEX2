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
    /// Interaction logic for Camere.xaml
    /// </summary>
    public partial class Camere : Window
    {
        public int myCameraCount = 0;
        public camin Camin;
        public utilizator Utilizator;
        public student Student { get; set; }
        public Camere(camin Camin, utilizator Utilizator,student student)
        {

            InitializeComponent();
            DataFormular camera = new DataFormular();
            this.Camin = Camin;
            this.Utilizator = Utilizator;
            this.Student = student;
            var camere = camera.GetCamere(this.Camin.id);

            foreach (var came in camere)
            {

                cardCamera card = new cardCamera(came, this.Camin, this.Utilizator,this.Student);
                myCameraCount++;
                if (myCameraCount % 3 == 0)
                {
                    MyCameraGrid.Height = 200 * (myCameraCount / 3) + 50;
                }
                else
                {
                    MyCameraGrid.Height = 200 * (myCameraCount / 3 + 1) + 50;
                }
                MyCameraGrid.Children.Add(card);
            }
        }
    }
}
