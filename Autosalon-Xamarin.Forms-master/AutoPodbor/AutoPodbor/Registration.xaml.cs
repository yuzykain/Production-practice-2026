using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoPodbor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            
            bool reg = Account.Registration(loginText.Text, passText.Text, retryPassText.Text);
            if (!reg)
            {
                await DisplayAlert("⚠ Ошибка!", "Введены неверные данные!\n - Аккаунт с таким логином существует.\n — Логин должен быть не короче 5 символов.\n - Пароль должен быть не короче 8 символов.\n - Пароли должны совподать.", "OK");
                loginText.Text = String.Empty;
                passText.Text = String.Empty;
                retryPassText.Text = String.Empty;

            }
            else
            {
                await DisplayAlert("✅ Регистрация", "Регистрация прошла успешно!", "OK");
                (Application.Current).MainPage = new MainPage();

            }

        }
    }
}