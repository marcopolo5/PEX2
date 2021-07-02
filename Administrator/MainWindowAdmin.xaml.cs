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
using Rooms;

namespace Administrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
        public MainWindowAdmin()
        {
            InitializeComponent();
        }

        private void guidelineBtn_Click(object sender, RoutedEventArgs e)
        {
            mainText.Visibility = Visibility.Hidden;
            guideLinePnl.Visibility = Visibility.Visible;
        }

        private void maintextviewBtn_Click(object sender, RoutedEventArgs e)
        {
            mainText.Visibility = Visibility.Visible;
            guideLinePnl.Visibility = Visibility.Hidden;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
