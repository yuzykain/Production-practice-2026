using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfPM02AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Page
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutoShowBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = AutoShowBDEntities.GetContext().Автомобили.ToList();
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BluForRemoving = DGrid.SelectedItems.Cast<Автомобили>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие{BluForRemoving.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    AutoShowBDEntities.GetContext().Автомобили.RemoveRange(BluForRemoving);
                    AutoShowBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = AutoShowBDEntities.GetContext().Автомобили.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddPageCars(null));
        }

        private void DGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddPageCars((sender as Button).DataContext as Автомобили));
        }

       
    }
}
