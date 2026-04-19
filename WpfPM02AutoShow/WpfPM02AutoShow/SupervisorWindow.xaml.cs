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

namespace WpfPM02AutoShow
{
    /// <summary>
    /// Логика взаимодействия для SupervisorWindow.xaml
    /// </summary>
    public partial class SupervisorWindow : Window
    {
        public SupervisorWindow()
        {
            InitializeComponent();
            
        }
        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void ListCars_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Cars());
            ManagerAS.MainFrame = MainFrame;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.GoBack();
        }

        private void SpsokSotrud_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Employees());
            ManagerAS.MainFrame = MainFrame;
        }

        private void ListOfClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ListOfClients());
            ManagerAS.MainFrame = MainFrame;
        }

        private void PageTreaties_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageTreaties());
            ManagerAS.MainFrame = MainFrame;
        }

        private void TestDriveBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageTestDrives());
            ManagerAS.MainFrame = MainFrame;
        }
    }
}
