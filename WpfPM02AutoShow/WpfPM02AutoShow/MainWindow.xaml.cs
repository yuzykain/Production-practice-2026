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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitForm(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveForm(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AutoShowBDEntities()) //Подключение бд
            {
                var usern = db.Сотрудники.FirstOrDefault(p => p.Логин == loginTextBox.Text && p.Пароль == passwordBox.Password);
                if (loginTextBox.Text == "" || passwordBox.Password == "")
                {
                    MessageBox.Show("Введите Логин и/или пароль");
                }
                else
                if (usern == null)
                {
                    MessageBox.Show("Неверно введён логин или пароль");
                }
                else
                if (Convert.ToString(usern.Должности.НаименованиеДолжности) == "Админ")
                {
                    MessageBox.Show("Добро пожаловать, Руководитель");
                    SupervisorWindow n = new SupervisorWindow();
                    n.Show();
                    this.Close();
                }
                else
                if (Convert.ToString(usern.Должности.НаименованиеДолжности) == "Бухгалтер")
                {
                    MessageBox.Show("Добро пожаловать, Бухгалтер");
                    AccountantWindow n = new AccountantWindow();
                    n.Show();
                    this.Close();
                }
                else
                if (Convert.ToString(usern.Должности.НаименованиеДолжности) == "Главный менеджер")
                {
                    MessageBox.Show("Добро пожаловать, Главный менеджер");
                    GeneralManagerWindow n = new GeneralManagerWindow();
                    n.Show();
                    this.Close();
                }
                else
                if (Convert.ToString(usern.Должности.НаименованиеДолжности) == "Менеджер")
                {
                    MessageBox.Show("Добро пожаловать, Менеджер");
                    ManagerWindow n = new ManagerWindow();
                    n.Show();
                    this.Close();
                }
            }
        }

        private void CheckBoxPwd_Click1(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                passwordTextBox.Text = passwordBox.Password;
                passwordTextBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordBox.Password = passwordTextBox.Text;
                passwordTextBox.Visibility = Visibility.Hidden;
                passwordBox.Visibility = Visibility.Visible;
            }
        }
    }
}
