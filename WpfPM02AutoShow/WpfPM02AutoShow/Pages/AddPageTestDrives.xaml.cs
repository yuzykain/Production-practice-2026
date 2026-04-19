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
    /// Логика взаимодействия для AddPageTestDrives.xaml
    /// </summary>
    public partial class AddPageTestDrives : Page
    {
        private ТестДрайв _currenBlu = new ТестДрайв();

        public AddPageTestDrives(ТестДрайв SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currenBlu.id_ТестДрайв.ToString()))
                errors.AppendLine("Укажите код тест драйва");
            if (_currenBlu.Дата == null)
                errors.AppendLine("Укажите дату");
            if (_currenBlu.Время == null)
                errors.AppendLine("Укажите время");
            if (_currenBlu.Автомобили.Марка == null)
                errors.AppendLine("Укажите автомобиль");
            if (_currenBlu.Примечание == null)
                errors.AppendLine("Напишите примечание");
            if (_currenBlu.СтатусВыполнения == null)
                errors.AppendLine("Укажите статус выполнения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenBlu.id_ТестДрайв == 0)
                AutoShowBDEntities.GetContext().ТестДрайв.Add(_currenBlu);
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
