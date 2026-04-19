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
    /// Логика взаимодействия для AddPageTreaties.xaml
    /// </summary>
    public partial class AddPageTreaties : Page
    {
        private Договоры _currenBlu = new Договоры();

        public AddPageTreaties(Договоры SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //if (string.IsNullOrWhiteSpace(_currenBlu.id_Договора.ToString()))
            //    errors.AppendLine("Укажите код договора");
            if (_currenBlu.Дата == null)
                errors.AppendLine("Укажите дату");
            //if (_currenBlu.Сотрудники.ФИО == null)
            //    errors.AppendLine("Укажите сотрудника");
            if (_currenBlu.Автомобили.Марка == null)
                errors.AppendLine("Укажите автомобиль");
            //if (_currenBlu.Автомобили.Цена == null)
            //    errors.AppendLine("Укажите цену");
            //if (_currenUsl.СпособыОплаты.НазваниеСпособаОплаты == null)
            //    errors.AppendLine("Укажите способ оплаты");
            if (_currenBlu.СтатусВыполнения == null)
                errors.AppendLine("Укажите статус выполнения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenBlu.id_Договора == 0)
                AutoShowBDEntities.GetContext().Договоры.Add(_currenBlu);
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
