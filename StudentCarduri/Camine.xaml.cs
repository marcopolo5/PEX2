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
    /// Interaction logic for Window1.xaml
    /// </summary>
   // <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Camine : Window
    {
        public utilizator Utilizator;
        private int myCaminCount = 0;
        public Camine(utilizator Utilizator)
        {
            InitializeComponent();
            this.Utilizator = Utilizator;
            DataFormular camin = new DataFormular();

            var camine = camin.GetCamin();

            foreach (var cam in camine)
            {

                cardCamin card = new cardCamin(cam, this.Utilizator);
                myCaminCount++;
                if (myCaminCount % 3 == 0)
                {
                    MyCaminGrid.Height = 150 * (myCaminCount / 3) + 100;
                }
                else
                {
                    MyCaminGrid.Height = 150 * (myCaminCount / 3 + 1) + 100;
                }
                MyCaminGrid.Children.Add(card);
            }
        }
    }
}
