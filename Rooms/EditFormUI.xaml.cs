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
using Rooms.ServicesModule;

namespace Rooms
{
    /// <summary>
    /// Interaction logic for EditFormUI.xaml
    /// </summary>
    public partial class EditFormUI : Window
    {     
            public formular Formular { get; set; }

            formular formular = new formular();

            FormularService formularService;
            public EditFormUI(formular formular)
            {
                InitializeComponent();
                formularService = new FormularService();

                this.formular = formular;
                 Formular = this.formular;
                DataContext = this;

                rezultatComboBox.ItemsSource= Enum.GetValues(typeof(Formular_Status)).Cast<Formular_Status>();

                SetValuexBoxesForm();
            }

            private void SetValuexBoxesForm()
            {

            rezultatComboBox.SelectedItem = formular.StareFormular;
          
            }
           

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void ValidateValues()
            {
               
                if (rezultatComboBox.SelectedItem == null)
                {
                    throw new Exception("Va rugam sa stabiliti daca studentul este admis sau respins !");
                }
            }
            public void UpdateFormular()
            {

            formular.StareFormular = (Formular_Status)rezultatComboBox.SelectedItem;
            Formular = formular;
        }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    ValidateValues();
                    UpdateFormular();
                    formularService.UpdateFormular(formular);//nu se actualizeaza in baza de date....

                using (RoomsContext roomsContext = new RoomsContext())
                {

                    var newStare = roomsContext.Formular.Max(x => x.StareFormular);

                    var returnedFormular = roomsContext.Formular.Where(x => x.StareFormular == newStare).ToString();


                    roomsContext.SaveChanges();
                }

                this.Close();
            }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }        

        }
    }