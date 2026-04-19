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
    /// Логика взаимодействия для AddEmployees.xaml
    /// </summary>
    public partial class AddEmployees : Page
    {
        private Сотрудники _currenBlu = new Сотрудники();

        public AddEmployees(Сотрудники SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currenBlu.id_Сотрудника.ToString()))
                errors.AppendLine("Укажите код сотрудника");
            if (_currenBlu.ФИО == null)
                errors.AppendLine("Укажите ФИО");
            //if (_currenUsl.Должности.НаименованиеДолжности == null)
            //    errors.AppendLine("Укажите Должность");
            //if (_currenUsl.ДатаРождения == null)
            //    errors.AppendLine("Укажите Дату рождения");
            //if (_currenUsl.ДатаПриёмаНаРаботу == null)
            //    errors.AppendLine("Укажите Дату приёма на работу");
            if (_currenBlu.Зарплата == null)
                errors.AppendLine("Укажите Зарплату");
            if (_currenBlu.Телефон == null)
                errors.AppendLine("Укажите Телефон");
            if (_currenBlu.Email == null)
                errors.AppendLine("Укажите Email");
            if (_currenBlu.Логин == null)
                errors.AppendLine("Укажите Логин");
            if (_currenBlu.Пароль == null)
                errors.AppendLine("Укажите Пароль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenBlu.id_Сотрудника == 0)
                AutoShowBDEntities.GetContext().Сотрудники.Add(_currenBlu);
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
