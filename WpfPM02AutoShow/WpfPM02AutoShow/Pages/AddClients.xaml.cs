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

namespace WpfPM02AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Page
    {
        private Клиенты _currenBlu = new Клиенты();

        public AddClients(Клиенты SelectedBuh)
        {
            InitializeComponent();
            if (SelectedBuh != null)
                _currenBlu = SelectedBuh;
            DataContext = _currenBlu;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currenBlu.id_клиента.ToString()))
                errors.AppendLine("Укажите код сотрудника");
            if (_currenBlu.ФИО == null)
                errors.AppendLine("Укажите ФИО");
            if (_currenBlu.Телефон == null)
                errors.AppendLine("Укажите телефон");
            if (_currenBlu.Email == null)
                errors.AppendLine("Укажите электронную почту");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currenBlu.id_клиента == 0)
                AutoShowBDEntities.GetContext().Клиенты.Add(_currenBlu);
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
