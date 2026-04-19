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
    /// Логика взаимодействия для AddPageCars.xaml
    /// </summary>
    public partial class AddPageCars : Page
    {
        private Автомобили _currenBlu = new Автомобили();
        public AddPageCars(Автомобили SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
            ComboGroup.ItemsSource = AutoShowBDEntities.GetContext().Автомобили.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrWhiteSpace(_currenBlu.id_Автомобиля.ToString()))
                errors.AppendLine("Укажите код автомобиля");
                if (_currenBlu.Марка == null)
                    errors.AppendLine("Укажите Марка!");
                //if (_currenBlu.Поставщики.НаименованиеПоставщика == null)
                //    errors.AppendLine("Укажите поставщика");
                if (_currenBlu.Цвет == null)
                    errors.AppendLine("Укажите цвет!");
                if (_currenBlu.КоличествоМест == null)
                    errors.AppendLine("Укажите количество мест!");


                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }
                if (_currenBlu.id_Автомобиля == 0)
                AutoShowBDEntities.GetContext().Автомобили.Add(_currenBlu);
                try
                {
                AutoShowBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    ManagerAS.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            
        }
    }
}
