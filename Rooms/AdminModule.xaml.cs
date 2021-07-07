using Rooms.Data_Assets;
using Rooms.Entity;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminModule : Window
    {
        // private int FormulareCount = 0;
        private int FormulareExploreCount = 0;

        private utilizator Utilizator;
        public AdminModule(utilizator Utilizator)
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
                

        public void SetUser(utilizator utilizator)
        {
            Debug.WriteLine("set user: user = " + utilizator + " user id = " + utilizator.id);
            this.Utilizator = utilizator;
        }
       

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void InitializeazFormulare()
        {
            AdminFormularService courses = new AdminFormularService();
            var formulars = courses.GetFormulars();
            foreach (var formular in formulars)
            {
                var student = courses.GetStudent(formular.studentID);
                InfoFrame card = new InfoFrame(formular, student); //do not forget
                FormulareExploreCount++;
                if (FormulareExploreCount % 3 == 0)
                {
                    FormulareGrid.Height = 300 * (FormulareExploreCount / 3)+100;
                }
                else
                {
                    FormulareGrid.Height = 300 * (FormulareExploreCount / 3 + 1)+100;
                }
                card.formular = formular;
                FormulareGrid.Children.Add(card);

                card.MouseDoubleClick += new MouseButtonEventHandler(DoubleClickExploreCourseHandler);

                card.MenuItemEdit.Click += new RoutedEventHandler((sender, e) => EditCourseHandler(sender, e, card));
            }
        }

        public void EditCourseHandler(object sender, RoutedEventArgs e, InfoFrame card)
        {
            EditFormUI editCourseWindow = new EditFormUI(card.formular);
            editCourseWindow.ShowDialog();

            card.formular = editCourseWindow.Formular;
            UpdateEditedCard(card);

        }

        public void UpdateEditedCard(InfoFrame card)
        {
            //Conversie valoare tip int din category box in String, nu am solutie
            card.CourseCategory.Text = card.formular.StareFormular.ToString();
        }


        public void DoubleClickExploreCourseHandler(object sender, MouseButtonEventArgs e)
        {

            // CourseViewWindow window = new CourseViewWindow(this.Utilizator, ((Cards)sender).);
            //s  window.Show();
            this.Close();
        }


    }
}
