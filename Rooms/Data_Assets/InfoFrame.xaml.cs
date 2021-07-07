using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rooms.Data_Assets;
using Rooms.Entity;

namespace Rooms.Data_Assets
{/// <summary>
 /// Interaction logic for Cards.xaml
 /// </summary>
    public partial class InfoFrame : UserControl
       {

        public InfoFrame() { }

        public student student { get; set; }
        public InfoFrame(formular formular, student student)//nu clean code da e important
        {
            InitializeComponent();
            this.formular = formular;
            this.student = student;
            
            this.DataContext = this;
            CourseDescription.Visibility = Visibility.Visible;
        }

        public formular formular { get; set; }
      

       public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

       public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(InfoFrame));
       
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            CourseNameTxtBlock.Style = this.Resources["ClickCourseTextTemplate"] as Style;
            AuthorName.Style = this.Resources["ClickAuthorTextTemplate"] as Style;
            CourseDescription.Visibility = Visibility.Visible;
            CourseNameTxtBlock.Visibility = Visibility.Hidden;
            MedieTxtBlock.Visibility = Visibility.Hidden;
            CourseNameTxtBlock.Foreground = new SolidColorBrush(Colors.White);
            AuthorName.Visibility = Visibility.Hidden;
            CourseImage.Visibility = Visibility.Hidden;
            PointsImg.Source = new BitmapImage(new Uri("/Data_Assets/settings.png", UriKind.Relative));

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            CourseNameTxtBlock.Style = this.Resources["CourseTextTemplate"] as Style;
            AuthorName.Style = this.Resources["AuthorTextTemplate"] as Style;
            CourseDescription.Visibility = Visibility.Hidden;
            CourseNameTxtBlock.Visibility = Visibility.Visible;
            MedieTxtBlock.Visibility = Visibility.Visible;
            CourseNameTxtBlock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e3349"));
            AuthorName.Visibility = Visibility.Visible;
            CourseImage.Visibility = Visibility.Visible;
            PointsImg.Source = new BitmapImage(new Uri("/Data_Assets/settings.png", UriKind.Relative));

        }

        private void defaultGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            CourseNameTxtBlock.Style = this.Resources["ClickCourseTextTemplate"] as Style;
            AuthorName.Style = this.Resources["ClickAuthorTextTemplate"] as Style;
            CourseDescription.Visibility = Visibility.Visible;
            CourseNameTxtBlock.Visibility = Visibility.Hidden;
            MedieTxtBlock.Visibility = Visibility.Hidden;
            CourseNameTxtBlock.Foreground = new SolidColorBrush(Colors.White);

            AuthorName.Visibility = Visibility.Hidden;
            CourseImage.Visibility = Visibility.Hidden;
            PointsImg.Source = new BitmapImage(new Uri("/Data_Assets/settings.png", UriKind.Relative));

        }

        private void defaultGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            CourseNameTxtBlock.Style = this.Resources["CourseTextTemplate"] as Style;
            AuthorName.Style = this.Resources["AuthorTextTemplate"] as Style;
            CourseDescription.Visibility = Visibility.Hidden;
            CourseNameTxtBlock.Visibility = Visibility.Visible;
            MedieTxtBlock.Visibility = Visibility.Visible;
            AuthorName.Visibility = Visibility.Visible;
            CourseNameTxtBlock.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#2e3349"));
            CourseImage.Visibility = Visibility.Visible;
            PointsImg.Source = new BitmapImage(new Uri("/Data_Assets/settings.png", UriKind.Relative));

        }

        private void PointsImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Hand;
            if (e.ChangedButton == MouseButton.Left)
            {
                Image image = sender as Image;
                ContextMenu contextMenu = image.ContextMenu;
                contextMenu.PlacementTarget = image;
                contextMenu.IsOpen = true;
                e.Handled = true;
            }
        }
              
    }
}
