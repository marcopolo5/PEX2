using System.Windows.Controls;
using Rooms.Entity;

namespace Student
{
    /// <summary>
    /// Interaction logic for Cards.xaml
    /// </summary>
    public partial class Cards : UserControl
    {
        public Cards(camin caminn)
        {
            InitializeComponent();
            this.camin = caminn;
            this.DataContext = this;
        }

        public Cards(formular course)
        {
        }

        public camin camin { get;  set; }
    }
}
