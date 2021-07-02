using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using Rooms.Data_Assets;
using Rooms.Entity;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowAdmin : Window
    {
       // private int FormulareCount = 0;
        private int FormulareExploreCount = 0;

        private utilizator Utilizator;
        public MainWindowAdmin(utilizator Utilizator)
        {
            InitializeComponent();

            this.Utilizator = Utilizator;
            this.DB.Content = this.Utilizator.firstname;
            this.DataContext = this;

           InitializeazFormulare();
        }

        private void Open_Form(object sender, RoutedEventArgs e)
        {
            Formular f = new Formular();
            this.Close();
            f.Show();
        }

        private void Open_Map(object sender, RoutedEventArgs e)
        {
            //test t = new test();
            //t.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SetUser(utilizator utilizator)
        {
            Debug.WriteLine("set user: user = " + utilizator + " user id = " + utilizator.id);
            this.Utilizator = utilizator;
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

        public void InitializeazFormulare()
        {
            AdminFormularService courses = new AdminFormularService();
            var exploredCourses = courses.GetFormulars();
            foreach (var formular in exploredCourses)
            {
                InfoFrame card = new InfoFrame(formular);
                FormulareExploreCount++;
                if (FormulareExploreCount % 3 == 0)
                {
                    FormulareGrid.Height = 300 * (FormulareExploreCount / 3) + 100;
                }
                else
                {
                    FormulareGrid.Height = 300 * (FormulareExploreCount / 3 + 1) + 100;
                }
                card.formular = formular;
                FormulareGrid.Children.Add(card);

                card.MouseDoubleClick += new MouseButtonEventHandler(DoubleClickExploreCourseHandler);
            }
        }

        public void DoubleClickExploreCourseHandler(object sender, MouseButtonEventArgs e)
        {

            //CourseViewWindow window = new CourseViewWindow(this.Utilizator, ((Cards)sender).);
           // window.Show();
            this.Close();
        }


    }
}
