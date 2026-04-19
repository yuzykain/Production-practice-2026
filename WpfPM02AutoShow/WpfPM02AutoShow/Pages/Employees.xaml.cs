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

namespace WpfPM02AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutoShowBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = AutoShowBDEntities.GetContext().Сотрудники.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddEmployees(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BluForRemoving = DGrid.SelectedItems.Cast<Сотрудники>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие{BluForRemoving.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    AutoShowBDEntities.GetContext().Сотрудники.RemoveRange(BluForRemoving);
                    AutoShowBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = AutoShowBDEntities.GetContext().Сотрудники.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddEmployees((sender as Button).DataContext as Сотрудники));
        }
    }
}
