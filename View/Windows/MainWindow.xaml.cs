using FastType.View.Pages;
using System.Windows;

namespace FastType.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TypingTutorBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new TypingTutorPage());
        }

        private void RatingBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new RatingPage());
        }

        private void ProfileBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MainFraime.Navigate(new ProfilePage());
        }
    }
}
